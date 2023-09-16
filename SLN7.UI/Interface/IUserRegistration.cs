using SLN7.MODEL.ViewModel;

namespace SLN7.UI.Interface
{
    public interface IUserRegistration
    {
        Task<int> NewUserRegistration(UserRegistrationViewModel model);
        Task<UserRegistrationControlsViewModel> GetCountriesStatesList();
        Task<List<UserRegistrationViewModel>> GetUserRegisterList();
        Task<UserRegistrationControlsViewModel> GetParticularUserById(int userId);
        Task<int?> UpdateUserAsync(UserRegistrationViewModel model, int? userId);
    }
}
