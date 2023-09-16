using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.DATA.DBModel
{
    public class TblLeadSource
    {
        [Key]
        public int LeadSourceID { get; set; }
        public int? LeadSourceDeleteSpace { get; set; }
        public int UserId { get; set; }
        public bool? LeadSourceStatus { get; set; }
        public bool? LeadSourceRemkt { get; set; }
        public int? LeadSourceOrigID { get; set; }
        [MaxLength(50)]
        public string? LeadSourceText { get; set; }
        public DateTime? LeadSourceCreatedOn { get; set; }
        public DateTime? LeadSourceUpdateOn { get; set; }
        public int? LeadSourceUpdatedBy { get; set; }

    }
}
