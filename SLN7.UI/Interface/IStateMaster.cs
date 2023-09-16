using SLN7.MODEL.ViewModel;

namespace SLN7.UI.Interface
{
    public interface IStateMaster
    {
        Task<CountryStateViewModel> GetStates();
        Task<int> AddStates(StateMasterViewModel model);
        Task<int> UpdateStates(StateMasterViewModel model, int Id);
        Task<int> DeleteStates(int Id);
    }
}
