using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.UI.Interface;

namespace SLN7.UI.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly IUserRegistration _registration;
        public UserRegistrationController(IUserRegistration registration)
        {
            _registration = registration;
        }
        [HttpGet, Route("Users/GetState")]
        [HttpGet, Route("Users/GetState/{id}")]
        public async Task<IActionResult> UserRegistrationDetails()
        {
            //return null;
            UserRegistrationControlsViewModel viewModel = new UserRegistrationControlsViewModel();
            viewModel = await _registration.GetCountriesStatesList();
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersList()
        {
            try
            {
                var getList = await _registration.GetUserRegisterList();
                return View(getList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<JsonResult> AddNewUser(UserRegistrationViewModel model)
        {
            try
            {
                int? getresult = -1;
                getresult = await _registration.NewUserRegistration(model);
                return Json(getresult);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public async Task<JsonResult> GetUserDetailsById(int userId)
        {
            try
            {
                UserRegistrationControlsViewModel viewModel = new UserRegistrationControlsViewModel();
                viewModel = await _registration.GetParticularUserById(userId);
                return Json(viewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        public async Task<JsonResult> UpdateUserDetails(UserRegistrationViewModel model,int? userId)
        {
            try
            {
                var details = await _registration.UpdateUserAsync(model, userId);
                return Json(details);
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPatch]
        public async Task<JsonResult> UpdateUserDetails1(UserRegistrationViewModel model, int? userId)
        {
            try
            {
                var details = await _registration.UpdateUserAsync(model, userId);
                return Json(details);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
