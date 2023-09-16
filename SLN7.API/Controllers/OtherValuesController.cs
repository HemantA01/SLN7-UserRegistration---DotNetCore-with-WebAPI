using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;

namespace SLN7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherValuesController : ControllerBase
    {
        private readonly IOtherValues _iOtherValues;
        public OtherValuesController(IOtherValues iOtherValues)
        {
            _iOtherValues = iOtherValues;
        }
        [HttpGet, Route("GetOtherValues")]
        public async Task<IActionResult> GetvaluesList()
        {
            try
            {
                
                var result = await _iOtherValues.GetData();
                
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost, Route("InsertValues")]
        public async Task<IActionResult> InsertValuesList(List<SaveSampleVals1> data)
        {
            try
            {

                var result = await _iOtherValues.InsertData(data);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
