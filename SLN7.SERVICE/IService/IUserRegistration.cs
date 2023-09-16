using SLN7.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.IService
{
    public interface IUserRegistration
    {
        Task<int> RegisterUserAsync(UserRegistrationViewModel model);
        Task<List<CountryMasterViewModel>> GetCountriesList();
        Task<List<CountryStateMasterViewModel>> GetStatesList();
        Task<List<UserRegistrationViewModel>> GetUsersList();
        Task<UserRegistrationViewModel> GetUser(int? userId);
        Task<int?> UpdateUserAsync(UserRegistrationViewModel model, int? userId);
        Task<int?> UpdateFieldsAsync(UserRegistrationViewModel model, int? userId);
        List<ValuesRequired> GetValues();
    }
}
