using SLN7.DATA.DBModel;
using SLN7.MODEL.ViewModel;

namespace SLN7.UI.Interface
{
    public interface IUserDetails
    {
        Task<UserLoginViewModel> UserLogin(UserLoginViewModel model);
        Task<List<Employee>> GetAllEmp();
    }
}
