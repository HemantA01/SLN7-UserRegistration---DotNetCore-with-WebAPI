using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.DATA.DBModel
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int? EmpId { get; set; }
        [Required]
        [StringLength(40)]
        public string? EmpFName { get; set; }
        [StringLength(40)]
        public string? EmpLName { get; set; }
        [StringLength(30)]
        public string? EmpUserName { get; set; }
        [StringLength(50)]
        public string? EmpEmailId { get; set; }
        [StringLength(15)]
        public string EmpPassword { get; set; }
        [StringLength(10)]
        public string? EmpMobileNo { get; set; }
        [StringLength(10)]
        public DateTime? DOJ { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [StringLength(50)]
        public string? Branch { get; set; }
        [StringLength(50)]
        public string? Position{ get; set; }
        [DefaultValue(0.00)]
        public decimal? CTC_PA { get; set; }
        
    }
}
