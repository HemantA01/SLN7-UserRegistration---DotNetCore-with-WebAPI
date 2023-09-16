using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.UI.Interface;

namespace SLN7.UI.Controllers
{
    public class CountryMasterController : Controller
    {
        private readonly ICountryMaster _Icountry;
        public CountryMasterController(ICountryMaster Icountry)
        {
            _Icountry = Icountry;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountriesList()
        {
            var details = await _Icountry.GetAllCountries();
            return View(details);
        }
        [HttpPost]
        public async Task<JsonResult> AddCountries(CountryMasterViewModel model)
        {
            var details = await _Icountry.AddCountries(model);
            return Json(details);
        }
        [HttpPut]
        public async Task<JsonResult> UpdateCountries(int Id,CountryMasterViewModel model)
        {
            var details = await _Icountry.UpdateCountries(Id,model);
            return Json(details);
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteCountries(int Id)
        {
            var details = await _Icountry.DeleteCountries(Id);
            return Json(details);
        }
    }
}
