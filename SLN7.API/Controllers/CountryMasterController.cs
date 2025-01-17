using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;

namespace SLN7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryMasterController : ControllerBase
    {
        private readonly ICountryMaster _ICountry;
        public CountryMasterController(ICountryMaster ICountry)
        {
            _ICountry = ICountry;
        }
        [HttpGet, Route("GetAllCountries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var userid = HttpContext.Session.GetInt32("UserId");
                var getCountries = await _ICountry.GetAllCountries();
                //if (getCountries.Count > 0)
                //{
                //    return Ok(getCountries);
                //}
                //else
                //{
                //    MessageResponse msg = new MessageResponse();
                //    msg.Status = "Empty";
                //    msg.Message = "No Data Available";
                //    return Ok(msg);
                //}
                return Ok(getCountries);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost, Route("AddCountry")]
        public async Task<IActionResult> AddCountry(CountryMasterViewModel model)
        {
            try
            {
                //return BadRequest(null);
                var addCountry = await _ICountry.AddCountries(model);
                return Ok(addCountry);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut, Route("UpdateCountryDetails")]
        public async Task<IActionResult> UpdateCountry(int Id, CountryMasterViewModel model)
        {
            try
            {
                var updateCountry = await _ICountry.UpdateCountry(Id, model);
                return Ok(updateCountry);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete, Route("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int Id)
        {
            try
            {
                var deletecountry = await _ICountry.DeleteCountry(Id);
                return Ok(deletecountry);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet, Route("getcountry-byid")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            try
            {
                var getcountry = await _ICountry.GetCountry(id);
                if(getcountry!=null)
                    return Ok(getcountry);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
