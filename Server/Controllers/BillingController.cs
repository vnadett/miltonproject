using Microsoft.AspNetCore.Mvc;
using MiltonProject.DAL.Interfaces;
using MiltonProject.DAL.DTOs;

namespace miltonProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : Controller
    {
        protected readonly IBillingService _db;
        public BillingController(IBillingService db)
        {
            _db = db;
        }
        [HttpPost("UploadBillingRequest")]
        public async Task<ActionResult<bool>> UploadBillingRequest(Request obj)
        {
            try
            {
                var result = _db.UploadBill(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
