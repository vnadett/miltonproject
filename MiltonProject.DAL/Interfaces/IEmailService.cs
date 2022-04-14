using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.Interfaces
{
    public interface IEmailService
    {
        void EmailSender(string email);
    }
}
