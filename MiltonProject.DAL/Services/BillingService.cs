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
    public class BillingService : IBillingService
    {
        //upload the bill from administrator 
        public bool UploadBill(Request model)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            try
            {
                using (_db)
                {
                    var bill = new Billing()
                    {
                        BillingUserId = model.BillingUserId,
                        CreateDate = DateTime.Now,
                        DeadLine = model.DeadLine,
                        UploaderId = model.UploaderId,
                    };
                    _db.Billings.Add(bill);

                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
