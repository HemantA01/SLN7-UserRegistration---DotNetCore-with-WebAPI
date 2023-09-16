using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.MODEL.ViewModel
{
    public class LeadSourceViewModel
    {
        public int LeadSourceID { get; set; }
        public string LeadSourceText { get; set; }
        public int? UserId { get; set; }
        public bool? LeadSourceStatus { get; set; }
        public DateTime? LeadSourceCreatedDate { get; set; }
        public string? IsLeadSrcActive { get; set; }
    }
}
