using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.MODEL.ViewModel
{
    public class UserRegistrationViewModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string UserFname { get; set; }
        public string? UserLname { get; set; }
        public string? UserContact { get; set; }
        public string UserEmail { get; set; }
        public DateTime DOB { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? TemporaryAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string? City { get; set; }
        public int? EmploymentId { get; set; }      //Freelancer    //Salaried  //Business  //Student
        public string? Employment { get; set; }
        public DateTime? UserCreatedOn { get; set; }
        public int? UserCreatedBy { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public int? ProfileImageId { get; set; }
    }

    public class ValuesRequired
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public enum EnumValuesRequired
    {
        Required,
        Conditional
    }
    public class SaveSampleVals1
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }

    public enum ActionVals
    {
        Read=2
    }
}
