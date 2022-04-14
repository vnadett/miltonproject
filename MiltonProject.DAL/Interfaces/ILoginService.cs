using MiltonProject.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.Interfaces
{
    public interface ILoginService
    {
        Login Login(Login loginUser);
    }
}
