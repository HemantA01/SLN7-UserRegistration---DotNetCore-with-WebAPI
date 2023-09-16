using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.DATA.DBModel
{
    public class TblStateMaster
    {
        [Key]
        public int Id { get; set; }
        public int? CountryId { get; set; }
        [MaxLength(55)]
        public string? StateName { get; set; }
        [MaxLength(5)]
        public string? StateAbb { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
