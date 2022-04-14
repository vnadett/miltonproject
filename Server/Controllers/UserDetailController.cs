using Microsoft.AspNetCore.Mvc;
using MiltonProject.DAL.Interfaces;
using MiltonProject.DAL.DTOs;

namespace miltonProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : Controller
    {
        protected readonly IUserDetailService _db;

        public UserDetailController(IUserDetailService db)
        {
            _db = db;
        }
        [HttpPost("Details")]
        public async Task<ActionResult<bool>> UploadDetails(Details obj)
        {
            try
            {
                var result = _db.UploadDetails(obj);
                await Task.FromResult(result);
                if (result) { return Ok(); }
                else return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [HttpGet("GetDetails")]
        public async Task<ActionResult<Details>> Get(int id)
        {
            try
            {
                var result = _db.GetDetails(id);
                await Task.FromResult(result);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
    }
}
