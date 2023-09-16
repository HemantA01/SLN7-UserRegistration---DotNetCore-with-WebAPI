using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.MODEL.ViewModel
{
    public class CountryWithStateListViewModel
    {
        public CountryWithStateListViewModel()
        {
            stateMasterLst = new List<StateMasterViewModel>();
        }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryAbb { get; set; }
        public List<StateMasterViewModel>? stateMasterLst { get; set; }
    }
}
