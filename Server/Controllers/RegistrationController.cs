using Microsoft.AspNetCore.Mvc;
using MiltonProject.DAL.Interfaces;
using MiltonProject.DAL.DTOs;
using System.Web.Http.Cors;
using MiltonProject.DAL.Models;

namespace miltonProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {

        protected readonly IRegistrationService _db;
        public RegistrationController(IRegistrationService db)
        {
            _db = db;
        }

        [HttpPost("Registration")]
        public async Task<ActionResult<bool>> Registration(Registration newUser)
        {
            try
            {
                Registration user = _db.Registration(newUser);
                await Task.FromResult(user);
                if (user.Success) { return Ok(); }
                else return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDetailsAndLogin>>> GetUsers()
        {
            try
            {
                List<UserDetailsAndLogin> users = _db.GetUsers();
                await Task.FromResult(users);
                if (users.Count != 0) { return Ok(users); }
                else return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpPost("ChangePass")]
        public async Task<ActionResult<bool>> ChangePassword(User model)
        {
            try
            {
                _db.ChangePassword(model);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.ToString()); }
        }
    }
}
