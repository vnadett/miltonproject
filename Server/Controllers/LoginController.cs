using Microsoft.AspNetCore.Mvc;
using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Interfaces;

namespace miltonProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        protected readonly ILoginService _db;
        public LoginController(ILoginService db)
        {
            _db = db;
        }
        [HttpPost("Login")]

        public async Task<ActionResult<Login>> Login(Login loginUser)
        {
            Login user = _db.Login(loginUser);
            return await Task.FromResult(user);
        }
    }
}
