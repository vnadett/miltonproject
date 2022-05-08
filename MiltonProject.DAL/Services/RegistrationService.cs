using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiltonProject.DAL.Interfaces;
using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Models;


namespace MiltonProject.DAL.Services
{
    public class RegistrationService : IRegistrationService
    {
        //registration
        public Registration Registration(Registration model)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            try
            {
                using (_db)
                {
                    if (!UserNameOrEmailWasTaken(model.Email, model.UserName))
                    {
                        throw new Exception("Ezen adatok valamelyikével már regisztráltak.");
                    }
                    else
                    {
                        User user = new User()
                        {
                            Email = model.Email,
                            UserName = model.UserName,
                            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                            Role = model.Role
                        };

                        _db.User.Add(user);
                        _db.SaveChanges();
                        int userId = user.Id;
                        IEmailService emailService = new EmailService();

                        string emailBody = "A Milton Friedman Egyetem számlázási rendszerébe ezzel az e-mail címmel regisztráció történt.\n\n" +
                            "Felhasználónév: " + model.UserName + "\n" +
                            "Jelszó: " + model.Password + "\n\n" +
                            "Az első bejelentkezéskor a jelszó megváltoztatása javasolt.";
                        string title = "Regisztrációs információ";

                        emailService.EmailSender(model.Email, emailBody, title);

                        return _db.User.Where(w => w.Id == userId).Select(s => new Registration
                        {
                            Email = s.Email,
                            UserName = s.UserName,
                            Error = "Sikeres regisztráció",
                            Success = true
                        }).FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Sikertelen regisztráció!");

            }

        }
        //check if the username or the email address is already taken
        public bool UserNameOrEmailWasTaken(string email, string username)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            User userList = new User();
            using (_db)
            {
                userList = _db.User.Where(w => w.Email == email || w.UserName == username).Select(s => s).FirstOrDefault();

            }
            if (userList == null)
            {
                return true;
            }
            else if (userList.Email == null && userList.UserName == null)
            {
                return true;
            }
            else
                return false;
        }
        //get users
        public List<UserDetailsAndLogin> GetUsers()
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            List<User> userList = new();
            List<DAL.Models.UserDetails> detailsList = new();
            List<UserDetailsAndLogin> userDetailsList = new();
            using (_db)
            {
                userList = _db.User.Select(s => s).ToList();
                detailsList = _db.UserDetails.Select(s => s).ToList();
                foreach (var u in userList)
                {
                    foreach (DAL.Models.UserDetails details in detailsList)
                    {
                        if (details.UserId == u.Id)
                        {
                            var user = new UserDetailsAndLogin
                            {
                                Email = u.Email,
                                UserName = u.UserName,
                                FirstName = details.FirstName,
                                LastName = details.LastName,
                                IsActive = details.IsActive,
                                IsBilling = details.IsBilling,
                                Role = u.Role,
                                UserId = u.Id,
                            };
                            userDetailsList.Add(user);
                        }
                        else
                        {
                            if (userDetailsList.Where(w => w.UserId == u.Id).FirstOrDefault() == null)
                            {
                                var user = new UserDetailsAndLogin
                                {
                                    Email = u.Email,
                                    UserName = u.UserName,
                                    Role = u.Role,
                                    UserId = u.Id,
                                };
                                userDetailsList.Add(user);
                            }
                        }
                    }
                }

                return userDetailsList;
            }
        }
        // change user password
        public bool ChangePassword(User model)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            using (_db)
            {
                var user = _db.User.Where(w => w.Id == model.Id).FirstOrDefault();
                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                    _db.Update(user);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
