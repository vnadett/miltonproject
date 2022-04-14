using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiltonProject.DAL.Interfaces;

namespace MiltonProject.DAL.Services
{
    public class UserDetailService : IUserDetailService
    {
        //upload user profile details
        public bool UploadDetails(Details model)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            try
            {
                using (_db)
                {
                    if (GetDetails(model.UserId) != null)
                    {
                        var d = _db.UserDetails.Where(w => w.UserId == model.UserId).First();
                        d.FirstName = model.FirstName;
                        d.LastName = model.LastName;
                        d.IsBilling = model.IsBilling;
                        d.IsActive = model.IsActive;
                        _db.UserDetails.Update(d);
                    }
                    else
                    {
                        UserDetails detail = new UserDetails()
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            IsActive = model.IsActive,
                            IsBilling = model.IsBilling,
                            UserId = model.UserId,
                        };
                        _db.UserDetails.Add(detail);
                    }
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        //get user details
        public UserDetails GetDetails(int id)
        {
            UserDetails model = new();
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            try
            {
                using (_db)
                {
                    model = _db.UserDetails.Where(x => x.UserId == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
