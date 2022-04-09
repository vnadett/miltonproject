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
    }
}
