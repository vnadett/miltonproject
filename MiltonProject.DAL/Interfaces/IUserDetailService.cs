using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.Interfaces
{
    public interface IUserDetailService
    {
        bool UploadDetails(Details model);
        UserDetails GetDetails(int id);
    }
}
