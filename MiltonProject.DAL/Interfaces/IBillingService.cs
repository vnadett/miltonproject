using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.Interfaces
{
    public interface IBillingService
    {
        bool UploadBill(Request model);
        List<Billing> GetBillsByUserId(int id);
        bool UploadFile(string path, int id);
        List<Billing> GetBillings();
        bool DeleteBill(int id);
    }
}
