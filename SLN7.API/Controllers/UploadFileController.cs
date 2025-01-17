using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SLN7.SERVICE.IService;
using System.Net;

namespace SLN7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFile _upload;
        private IWebHostEnvironment _webHostEnvironment;
        public UploadFileController(IUploadFile upload, IWebHostEnvironment webHostEnvironment)
        {
            _upload = upload;
            _webHostEnvironment = webHostEnvironment;
        }
       [HttpPost, Route("upload-image")]
        public async Task<IActionResult> UploadImages([FromForm] IFormFile file)
        {
            try
            {
                var isFileUploaded = await _upload.UploadImage(file);
                if (isFileUploaded)
                {
                    return Ok(HttpStatusCode.OK);
                }
                else
                {
                    return BadRequest(HttpStatusCode.NotImplemented);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
                throw;
            }
        }
        [HttpPost, Route("upload-bulkrecords-excel")]
        public async Task<IActionResult> UploadExcelWithRecords(IFormFile file)
        {
            try
            {
                var isFileUploaded = await _upload.UploadExcelInsertBulkRecords(file);
                if (isFileUploaded)
                {
                    return Ok(HttpStatusCode.OK);
                }
                else
                {
                    return BadRequest(HttpStatusCode.NotImplemented);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                throw;
            }
        }
    }
}
