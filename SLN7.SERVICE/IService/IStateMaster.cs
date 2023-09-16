using SLN7.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.IService
{
    public interface IStateMaster
    {
        Task<List<CountryStateMasterViewModel>> GetStatesList();
        Task<List<CountryMasterViewModel>> GetCountriesList();
        Task<int> AddStatesAgainstCountries(StateMasterViewModel model);
        Task<int> UpdateStates(int Id, int? CountryId, StateMasterViewModel model);
        Task<int> DeleteState(int Id);
        Task<List<CountryWithStateListViewModel>> GetCountryWithStateList();
    }
}
