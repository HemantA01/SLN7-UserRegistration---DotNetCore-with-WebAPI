using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SLN7.DATA.DBModel;
using SLN7.MODEL.Logger;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;

namespace SLN7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        public readonly IUserDetails _iUser;
        public UserDetailsController(IUserDetails iUser)
        {
            _iUser = iUser;
        }
        [HttpPost,Route("VerifyUserExistence")]
        public async Task<IActionResult> VerifyUser(UserLoginViewModel model)
        {
            try
            {
                var verifyUser = await _iUser.UserLogin(model);
                HttpContext.Session.SetInt32("UserId", (int)verifyUser.UserId);
                Log.Information("API output-- "+ verifyUser);
                GenerateLog.WriteLog(verifyUser.ToString());
                return Ok(verifyUser);
            }
            catch (Exception ex)
            {
                GenerateLog.WriteLog(ex.Message);
                throw;
            }
        }
        [HttpGet]
        [Route("getallemployees")]
        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                var verifyUser = _iUser.GetAllEmp();
                return await Task.FromResult(verifyUser);
            }
            catch (Exception ex)
            {
                GenerateLog.WriteLog(ex.Message);
                throw;
            }
        }


    }
}
