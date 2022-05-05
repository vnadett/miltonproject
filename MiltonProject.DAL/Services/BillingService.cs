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
        //get bills by userId
        public List<Billing> GetBillsByUserId(int id)
        {

            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());

            using (_db)
            {
                var bills = _db.Billings.Where(w => w.BillingUserId == id).ToList();

                return bills;
            }
        }
        //upload files to the bill requests
        public bool UploadFile(string path, int id)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            using (_db)
            {
                try
                {
                    var bill = _db.Billings.Where(w => w.Id == id).Select(s => s).FirstOrDefault();
                    bill.FileName = path;
                    bill.UpdateDate = DateTime.Now;
                    _db.Billings.Update(bill);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception) { return false; }


            }
        }
    }
}
