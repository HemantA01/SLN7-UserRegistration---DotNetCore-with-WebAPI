using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.DATA.DBModel
{
    public class TblUserRegistration
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [MaxLength(100)]
        public string UserFname { get; set; }
        [MaxLength(100)]
        public string? UserLname { get; set; }
        [MaxLength(50)]
        public string? UserContact { get; set; }
        [MaxLength(250)]
        public string UserEmail { get; set; }
        public DateTime DOB { get; set; }
        [MaxLength(20)]
        public string? Gender { get; set; }
        [MaxLength(30)]
        public string? Nationality { get; set; }
        [MaxLength(250)]
        public string? TemporaryAddress { get; set; }
        [MaxLength(250)]
        public string? PermanentAddress { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        public int? EmploymentId { get; set; }      //Freelancer    //Salaried  //Business  //Student
        [MaxLength(50)]
        public string? Employment { get; set; }
        public DateTime? UserCreatedOn { get; set; }
        public int? UserCreatedBy { get; set; }
        public int? UploadFileId { get; set; }
    }
}
