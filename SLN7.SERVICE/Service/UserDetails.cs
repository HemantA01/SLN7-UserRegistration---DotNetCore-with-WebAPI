using Microsoft.EntityFrameworkCore;
using Serilog;
using SLN7.DATA.DBContext;
using SLN7.DATA.DBModel;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.Service
{
    public class UserDetails : IUserDetails
    {
        public readonly ApplicationContext _context;
        public UserDetails(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<UserLoginViewModel> UserLogin(UserLoginViewModel model)
        {
            try
            {
                var getUserDetails = await _context.tblUserLogin.Where(x => x.UserName == model.UserName && x.UserPassword == model.Password).Select(x => new UserLoginViewModel
                {
                    UserId = x.UserId/*,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn*/
                }).FirstOrDefaultAsync();
                Log.Information("getUserDetails output: " + getUserDetails);
                return getUserDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Employee> GetAllEmp()
        {
            try
            {
                List<Employee> getUserDetails = _context.Employee.ToList();
                return getUserDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
