using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Interfaces;

namespace miltonProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        protected readonly IEmailService _db;
        public EmailController(IEmailService db)
        {
            _db = db;
        }
        [HttpPost("Email")]

        public async Task<ActionResult<bool>> Login(Email address)
        {
            _db.EmailSender(address.EmailAddress);
            return Ok(true);
        }
    }
}
