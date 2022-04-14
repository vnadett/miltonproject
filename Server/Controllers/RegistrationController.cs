using Microsoft.AspNetCore.Mvc;
using MiltonProject.DAL.Interfaces;
using MiltonProject.DAL.DTOs;
using System.Web.Http.Cors;

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

    }
}
