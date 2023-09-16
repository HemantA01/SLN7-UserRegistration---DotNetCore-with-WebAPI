using SLN7.DATA.DBModel;
using SLN7.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.IService
{
    public interface IUserDetails
    {
        Task<UserLoginViewModel> UserLogin(UserLoginViewModel model);
        List<Employee> GetAllEmp();
    }
}
