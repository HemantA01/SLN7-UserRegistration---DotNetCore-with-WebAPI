using Microsoft.AspNetCore.Mvc;
using Serilog;
using SLN7.UI.Interface;
using System.Net;

namespace SLN7.UI.Controllers
{
    public class UploadFileController : Controller
    {
        private readonly IUploadFile _file;

        public UploadFileController(IUploadFile file)
        {
            _file = file;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult UploadFiles() 
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> UploadImage(IFormFile file) 
        {
            try
            {
                var getresult = await _file.UploadFileAsync(file);
                return Json(getresult);
            }
            catch (Exception ex)
            {
                Log.Information(ex.Message);
                throw;
            }
        }
    }
}
