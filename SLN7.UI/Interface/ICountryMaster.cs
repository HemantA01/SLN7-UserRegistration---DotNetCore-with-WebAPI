using SLN7.MODEL.ViewModel;

namespace SLN7.UI.Interface
{
    public interface ICountryMaster
    {
        Task<List<CountryMasterViewModel>> GetAllCountries();
        Task<int> AddCountries(CountryMasterViewModel model);
        Task<int> UpdateCountries(int Id, CountryMasterViewModel model);
        Task<int> DeleteCountries(int Id);
    }
}
