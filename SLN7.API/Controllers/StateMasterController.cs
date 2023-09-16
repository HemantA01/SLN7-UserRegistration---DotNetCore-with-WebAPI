using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;

namespace SLN7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateMasterController : ControllerBase
    {
        private readonly IStateMaster _state;
        public StateMasterController(IStateMaster state)
        {
            _state=state;
        }
        [HttpGet]
        [Route("GetStateList")]
        public async Task<IActionResult> GetStateList()
        {
            try
            {
                CountryStateViewModel model = new CountryStateViewModel();
                model.countrystateMasterViewModel = await _state.GetStatesList();
                model.countryMasterViewModel = await _state.GetCountriesList();
                return Ok(model);
            }
            catch (Exception)
            {                throw;
            }
        }

        [HttpPost]
        [Route("AddStates")]
        public async Task<IActionResult> AddStates(StateMasterViewModel model)
        {
            try
            {
                var addStates = await _state.AddStatesAgainstCountries(model);
                return Ok(addStates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateStates")]
        public async Task<IActionResult> UpdateStateDetails(int Id, int? CountryId, StateMasterViewModel model)
        {
            try
            {
                var updateVal = await _state.UpdateStates(Id, CountryId, model);
                return Ok(updateVal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteState")]
        public async Task<IActionResult> DeleteState(int Id)
        {
            try
            {
                var updateVal = await _state.DeleteState(Id);
                return Ok(updateVal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To get list of state within particular country
        /// </summary>
        [HttpGet("GetStateListWithCountry")]
        public async Task<IActionResult> GetStateListWithCountryList()
        {
            try
            {
                var data = await _state.GetCountryWithStateList();
                return Ok(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
