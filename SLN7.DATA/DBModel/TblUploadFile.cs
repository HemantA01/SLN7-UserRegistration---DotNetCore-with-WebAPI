using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.DATA.DBModel
{
    public class TblUploadFile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? FileName { get; set; }
        [StringLength(100)]
        public string? FileType { get; set; }
        [StringLength(30)]
        public string? FileExtension { get; set; }
        [StringLength(200)]
        public string? FilePath { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? FileStatus { get; set; }
        public int? UserId { get; set; }
    }
}
