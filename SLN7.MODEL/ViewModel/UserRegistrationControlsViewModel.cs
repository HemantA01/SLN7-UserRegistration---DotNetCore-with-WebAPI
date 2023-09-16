using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.MODEL.ViewModel
{
    public class UserRegistrationControlsViewModel
    {
        public UserRegistrationControlsViewModel()
        {
            countryMasterLst = new List<CountryMasterViewModel>();
            stateMasterLst = new List<CountryStateMasterViewModel>();
            newUserRegistration = new UserRegistrationViewModel();
            UserRegistrationLst = new List<UserRegistrationViewModel>();
        }
        public List<CountryMasterViewModel> countryMasterLst { get; set; }
        public List<CountryStateMasterViewModel> stateMasterLst { get; set; }
        public UserRegistrationViewModel newUserRegistration { get; set; }
        public List<UserRegistrationViewModel> UserRegistrationLst { get; set; }
    }
}
