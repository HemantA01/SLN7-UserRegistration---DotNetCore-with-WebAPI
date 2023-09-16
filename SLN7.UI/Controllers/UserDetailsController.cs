using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.UI.Interface;

namespace SLN7.UI.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly IUserDetails _iUser;
        public UserDetailsController(IUserDetails iUser)
        {
            _iUser = iUser;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VerifyUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> VerifyUser(UserLoginViewModel model)
        {
            try
            {
                var data = await _iUser.UserLogin(model);
                return RedirectToAction("DashboardHome", "Dashboard");
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            try
            {
                var data = await _iUser.GetAllEmp();
                return Json (data);
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }
    }
}
