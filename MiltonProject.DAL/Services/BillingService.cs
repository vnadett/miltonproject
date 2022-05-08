using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Interfaces;
using MiltonProject.DAL.Models;
using System.Timers;

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
                    var updatebill = _db.Billings.Where(w => w.Id == model.Id).FirstOrDefault();
                    if (updatebill != null)
                    {
                        updatebill.UpdateDate = DateTime.Now;
                        updatebill.IsAccepted = model.IsAccepted;
                        updatebill.CreateDate = (DateTime)model.CreateDate;

                        _db.Billings.Update(updatebill);
                    }
                    else
                    {
                        var bill = new Billing()
                        {
                            BillingUserId = model.BillingUserId,
                            CreateDate = DateTime.Now,
                            DeadLine = model.DeadLine,
                            UploaderId = model.UploaderId,
                        };
                        _db.Billings.Add(bill);
                    }
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
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

        // get all the bills
        public List<Billing> GetBillings()
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            using (_db)
            {
                var bills = _db.Billings.ToList();
                return bills;
            }
        }

        //delete bill
        public bool DeleteBill(int id)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            using (_db)
            {
                var bill = _db.Billings.Where(_w => _w.Id == id).FirstOrDefault();
                if (bill != null)
                    _db.Billings.Remove(bill);
                _db.SaveChanges(true);
                return true;
            }
        }

        //send email to users if they have expiring bill request
        public void ExpiringBillEmailSender()
        {
            const double interval = 15 * 1000;
            System.Timers.Timer checkForTime = new System.Timers.Timer(interval);
            checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
            checkForTime.Enabled = true;
        }
        void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            IEmailService email = new EmailService();
            string title = "Mai napon lejáró határidő!";
            using (_db)
            {
                var bills = _db.Billings.Where(w => w.DeadLine == DateTime.Today).ToList();
                var users = _db.User.ToList();
                foreach (var bill in bills)
                {
                    foreach (var user in users)
                    {
                        if (bill.BillingUserId == user.Id)
                        {
                            string body = "Tisztelt Felhasználó!\n\n"
                                + "A Milton Friedman Egyetem Számlázási rendszerében egy feltöltésre váró számlakérvénye van a mai határidővel." +
                                "\n\n";
                            email.EmailSender(user.Email, body, title);
                        }
                    }
                }
            }
        }
    }
}
