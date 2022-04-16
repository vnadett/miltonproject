using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Models;

namespace MiltonProject.DAL.Interfaces
{
    public interface IRegistrationService
    {
        Registration Registration(Registration model);
        bool UserNameOrEmailWasTaken(string email, string username);
        List<UserDetailsAndLogin> GetUsers();
    }
}
