using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.MODEL.ViewModel
{
    public class StateMasterViewModel
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string? StateName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? IsStateActive { get; set; }
    }

    public class CountryStateMasterViewModel
    {
        public int StateId { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }
        public bool? IsActive { get; set; }
        public string? IsCountryActive { get; set; }
        public string? IsStateActive { get; set; }
    }
}
