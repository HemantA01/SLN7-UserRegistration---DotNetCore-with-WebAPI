using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.DATA.DBModel
{
    public class TblCountryMaster
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(55)]
        public string? CountryName { get; set; }
        [MaxLength(5)]
        public string? CountryAbb { get; set; }  
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
