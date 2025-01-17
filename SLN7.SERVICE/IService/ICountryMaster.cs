using SLN7.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.IService
{
    public interface ICountryMaster
    {
        Task<List<CountryMasterViewModel>> GetAllCountries();
        Task<int> AddCountries(CountryMasterViewModel model);
        Task<int> UpdateCountry(int Id, CountryMasterViewModel model);
        Task<int> DeleteCountry(int Id);
        Task<CountryMasterViewModel> GetCountry(int Id);
    }
}
