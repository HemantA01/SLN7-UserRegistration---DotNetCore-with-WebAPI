using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.MODEL.ViewModel
{
    public class CountryStateViewModel
    {
        public CountryStateViewModel()
        {
            countrystateMasterViewModel = new List<CountryStateMasterViewModel>();
            countryMasterViewModel = new List<CountryMasterViewModel>();
            stateMasterViewModel = new StateMasterViewModel();
            stateMasterViewModelLst = new List<StateMasterViewModel>();
            countryMasterViewModelLst = new CountryMasterViewModel();
        }
        public List<CountryStateMasterViewModel> countrystateMasterViewModel { get; set; }
        public List<CountryMasterViewModel> countryMasterViewModel { get; set; }
        public StateMasterViewModel stateMasterViewModel { get; set; }
        public CountryMasterViewModel countryMasterViewModelLst { get; set; }      /////////////////////////////////////////
        public List<StateMasterViewModel> stateMasterViewModelLst { get; set; } /////
    }
}
