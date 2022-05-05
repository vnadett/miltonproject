using Microsoft.AspNetCore.Mvc;
using MiltonProject.DAL.Interfaces;
using MiltonProject.DAL.DTOs;
using MiltonProject.DAL.Models;

namespace miltonProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : Controller
    {
        protected readonly IBillingService _db;
        private readonly IWebHostEnvironment _env;
        public BillingController(IBillingService db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
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
        [HttpGet("GetBillsByUserId")]
        public async Task<ActionResult<List<Billing>>> GetBillsByUserId(int id)
        {
            try
            {
                var result = _db.GetBillsByUserId(id);
                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpPost("PostFile")]
        public async Task<ActionResult<bool>> PostFile([FromBody] UploadedFile uploadedFile, [FromQuery] int billId)
        {
            try
            {
                var path = $"{_env.WebRootPath}\\Users\\Bernadett\\Documents\\Coding\\miltonproject\\Files\\{uploadedFile.FileName}";
                var fs = System.IO.File.Create(path);
                fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
                fs.Close();
                _db.UploadFile(path, billId);
                return Ok(true);
            }
            catch (Exception ex) { return BadRequest(ex.ToString()); }
        }
    }
}
