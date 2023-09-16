using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;

namespace SLN7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistration _iUserRegister;
        public UserRegistrationController(IUserRegistration iUserRegister)
        {
            _iUserRegister = iUserRegister;
        }
        [HttpPost, Route("RegisterNewUser")]
        public async Task<IActionResult> AddNewUser(UserRegistrationViewModel model)
        {
            try
            {
                Log.Information("This is RegisterNewUser");
                var addnewuser = await _iUserRegister.RegisterUserAsync(model);
                return Ok(addnewuser);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet, Route("GetCountryStates")]
        public async Task<IActionResult> GetCountryState()
        {
            try
            {
                UserRegistrationControlsViewModel model = new UserRegistrationControlsViewModel();
                model.stateMasterLst = await _iUserRegister.GetStatesList();
                model.countryMasterLst = await _iUserRegister.GetCountriesList();
                //if (userId != null)
                //{
                //    model.newUserRegistration = await _iUserRegister.GetUser(userId);
                //}
                return Ok(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetRegisteredUsers()
        {
            try
            {
                var getusers = await _iUserRegister.GetUsersList();
                return Ok(getusers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetUsersWithId")]
        public async Task<IActionResult> GetRegisteredUsersWithId(int userId)
        {
            try
            {
                UserRegistrationControlsViewModel model = new UserRegistrationControlsViewModel();
                model.newUserRegistration = await _iUserRegister.GetUser(userId);
                return Ok(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("UpdateUserDetails")]
        public async Task<IActionResult> UpdateUserDetailsById(UserRegistrationViewModel model, int? userId)
        {
            try
            {
                var updatedetails = await _iUserRegister.UpdateUserAsync(model, userId);
                return Ok(updatedetails);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPatch("UpdateDetailsUsingId")]
        public async Task<IActionResult> UpdateUserDetailsUsingId(UserRegistrationViewModel model, int? userId)
        {
            try
            {
                var updatedetails = await _iUserRegister.UpdateFieldsAsync(model, userId);
                return Ok(updatedetails);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("ValuesRequired")]
        public  IActionResult GetValues()
        {
            try
            {
                var getValues = _iUserRegister.GetValues();
                return Ok(getValues);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
