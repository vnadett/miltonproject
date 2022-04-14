using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Interfaces;
using MiltonProject.DAL.Models;

namespace MiltonProject.DAL.Services
{
    public class LoginService : ILoginService
    {
        public Login Login(Login loginUser)
        {
            try
            {
                ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
                using (_db)
                {
                    User user = _db.User.Where(w => w.UserName == loginUser.UserName).Select(s => s).FirstOrDefault();
                    if (user != null && BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
                    {
                        return new Login { Id = user.Id, UserName = user.UserName, Success = true, Role = user.Role, Error = "Sikeres bejelentkezés" };
                    }
                    else
                    {
                        return new Login { Error = "Sikertelen bejelentkezés", Success = false };
                    }
                }
            }
            catch (Exception)
            {
                return new Login { Error = "Sikertelen bejelentkezés", Success = false };
            }
        }
    }
}
