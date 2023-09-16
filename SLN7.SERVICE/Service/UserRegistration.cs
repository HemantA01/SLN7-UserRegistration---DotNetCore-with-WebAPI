using Microsoft.EntityFrameworkCore;
using SLN7.DATA.DBContext;
using SLN7.DATA.DBModel;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace SLN7.SERVICE.Service
{
    public class UserRegistration : IUserRegistration
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _ihostenv;
        public UserRegistration(ApplicationContext context, IWebHostEnvironment ihostenv)
        {
            _context = context;
            _ihostenv = ihostenv;
        }
        public async Task<List<CountryMasterViewModel>> GetCountriesList()
        {
            try
            {
                var getcountries = await _context.tblCountryMaster.Where(x => x.IsActive == true).Select(x => new CountryMasterViewModel
                {
                    Id = x.Id,
                    CountryName = x.CountryName + " ( " + x.CountryAbb + " )",
                    CountryAbb = x.CountryAbb,
                    IsActive = x.IsActive
                }).ToListAsync();
                return getcountries; 
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<CountryStateMasterViewModel>> GetStatesList()
        {
            try
            {
                var getstates = await (from country in _context.tblCountryMaster
                                       join states in _context.tblStateMaster on country.Id equals states.CountryId
                                       where country.IsActive == true
                                       select new CountryStateMasterViewModel
                                       {
                                           StateName = states.StateName,
                                           CountryId = country.Id,
                                           StateId = states.Id,
                                           CountryName= country.CountryName + " ( " + country.CountryAbb + " )",
                                           IsCountryActive = country.IsActive==true?"Active":"Inactive",
                                           IsStateActive = states.IsActive==true? "Active" : "Inactive",
                                       }).ToListAsync();
                return getstates;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> RegisterUserAsync(UserRegistrationViewModel model)
        {
            try
            {
                int i = 0;
                var ifExists = await _context.tblUserRegistration.Where(x=>x.UserContact==model.UserContact && x.UserEmail==model.UserEmail).FirstOrDefaultAsync();
                if (ifExists == null)
                {
                    TblUserRegistration adduser = new TblUserRegistration();
                    adduser.UserFname=model.UserFname;
                    adduser.UserLname=model.UserLname; 
                    adduser.UserContact = model.UserContact;
                    adduser.UserEmail = model.UserEmail;
                    adduser.DOB = model.DOB;
                    adduser.Gender = model.Gender;
                    adduser.Nationality = model.Nationality;
                    adduser.TemporaryAddress = model.TemporaryAddress;
                    adduser.PermanentAddress = model.PermanentAddress;
                    adduser.CountryId = model.CountryId;
                    adduser.StateId = model.StateId;
                    adduser.City=model.City;
                    adduser.Employment=model.Employment;
                    _context.tblUserRegistration.Add(adduser);
                    i= await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        int j = 0;
                        adduser.UserId = adduser.Id;
                        j = await _context.SaveChangesAsync();
                        //await Execute().ConfigureAwait(false);
                        //await ExecuteEmail();
                    }
                    if (i > 0 && model.ProfileImage != null)
                    {
                        int isFileUpload = await UploadFile(model.ProfileImage, adduser.UserId);
                        if (isFileUpload > 0) 
                        {
                            adduser.UploadFileId = isFileUpload;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    i= -2;
                }
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static async Task Execute()
        {
            //var apiKey = Environment.GetEnvironmentVariable("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");
            //1st way
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("colloquim456@gmail.com", "Test User");
            var subject = "Sending mail with SendGrid for testing purpose";
            var to = new EmailAddress("kumarh1286@gmail.com", "mail from Sendgrid");
            var plainTextContent = "and easy to send to bulk number of users.";
            var htmlContent = "<strong>and easy to do anywhere with C#.</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
        public static async Task ExecuteEmail()
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("colloquim456@gmail.com", "Test User 2nd"),
                Subject = "Sending mail with SendGrid for testing purpose using SendGridMessage",
                PlainTextContent = "to send bulk emails",
                HtmlContent = "<strong>Hello User</strong>\n<h3>Thank you for exploring and using SendGrid Mail API to send mails to the recipients.</h3>" +
                "\n\nIn case you need any support, kindly drop a mail to us at <b>customer.support@sendgrid.com</b>." +
                " Our support executives will reach to you within a moment to assist you."
            };
            msg.AddTo(new EmailAddress("kumarh1286@gmail.com", "mail from Sendgrid"));
            msg.AddTo(new EmailAddress("hemantk3@chetu.com", "Sendgrid Testing"));
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }

        public async Task<List<UserRegistrationViewModel>> GetUsersList()
        {
            try
            {
                var getusers = await (from users in _context.tblUserRegistration
                                      join country in _context.tblCountryMaster on users.CountryId equals country.Id
                                      join state in _context.tblStateMaster on users.StateId equals state.Id
                                      select new UserRegistrationViewModel
                                      {
                                          UserId = users.UserId,
                                          UserFname = users.UserFname,
                                          UserLname = users.UserLname,
                                          UserContact = users.UserContact,
                                          UserEmail = users.UserEmail,
                                          DOB = users.DOB,
                                          //DOB = Convert.ToDateTime(users.DOB).ToString("dd-MM-yyyy"),
                                          //UserCreatedOn = Convert.ToDateTime(users.UserCreatedOn.ToString("dd-MM-yyyy")),
                                          Gender = users.Gender == "Male" ? "M" : "F",
                                          Nationality = users.Nationality,
                                          TemporaryAddress = users.TemporaryAddress,
                                          PermanentAddress = users.PermanentAddress,
                                          CountryId = users.CountryId,
                                          Country = country.CountryName + " (" + country.CountryAbb + ")",
                                          StateId = users.StateId,
                                          State = state.StateName,
                                          City = users.City
                                      }).ToListAsync();
                return getusers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async  Task<UserRegistrationViewModel> GetUser(int? userId)
        {
            try
            {
                var getdetails = await (from users in _context.tblUserRegistration
                                  join country in _context.tblCountryMaster on users.CountryId equals country.Id
                                  join state in _context.tblStateMaster on users.StateId equals state.Id
                                  where users.UserId == userId
                                  select new UserRegistrationViewModel
                                  {
                                      UserId = users.UserId,
                                      UserFname = users.UserFname,
                                      UserLname = users.UserLname,
                                      UserContact = users.UserContact,
                                      UserEmail = users.UserEmail,
                                      DOB = users.DOB,
                                      Gender = users.Gender == "Male" ? "M" : "F",
                                      Nationality = users.Nationality,
                                      TemporaryAddress = users.TemporaryAddress,
                                      PermanentAddress = users.PermanentAddress,
                                      CountryId = users.CountryId,
                                      Country = country.CountryName + " (" + country.CountryAbb + ")",
                                      StateId = users.StateId,
                                      State = state.StateName,
                                      City = users.City
                                  }).FirstOrDefaultAsync();
                return getdetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int?> UpdateUserAsync(UserRegistrationViewModel model, int? userId)
        {
            try
            {
                int? getResult = -1;
                var ifExists = await _context.tblUserRegistration.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    ifExists.UserFname = model.UserFname;
                    ifExists.UserLname = model.UserLname;
                    ifExists.UserContact = model.UserContact;
                    ifExists.UserEmail = model.UserEmail;
                    ifExists.DOB = model.DOB;
                    ifExists.Gender = model.Gender;
                    ifExists.Nationality = model.Nationality;
                    ifExists.TemporaryAddress = model.TemporaryAddress;
                    ifExists.PermanentAddress = model.PermanentAddress;
                    ifExists.CountryId = model.CountryId;
                    ifExists.StateId = model.StateId;
                    ifExists.City = model.City;
                    getResult = await _context.SaveChangesAsync();
                }
                else
                {
                    getResult = 0;
                }
                return getResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int?> UpdateFieldsAsync(UserRegistrationViewModel model, int? userId)
        {
            try
            {
                int? getResult = -1;
                var ifExists = await _context.tblUserRegistration.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    ifExists.UserFname = model.UserFname;
                    ifExists.UserLname = model.UserLname;
                    ifExists.UserContact = model.UserContact;
                    ifExists.TemporaryAddress = model.TemporaryAddress;
                    ifExists.PermanentAddress = model.PermanentAddress;
                    getResult = await _context.SaveChangesAsync();
                }
                else
                {
                    getResult = 0;
                }
                return getResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*public string InsertDataUsingSP(UserRegistrationViewModel model)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }*/
        public List<ValuesRequired> GetValues()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id",typeof(string));
                dt.Columns.Add("Name",typeof(string));
                dt.Rows.Add("Required","Required");
                dt.Rows.Add("Conditional", "Conditional");
                List<ValuesRequired> values = new List<ValuesRequired>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ValuesRequired valReq = new ValuesRequired();
                    valReq.Id = dt.Rows[i]["Id"].ToString();
                    valReq.Name = dt.Rows[i]["Name"].ToString();
                    values.Add(valReq);
                }
                return values.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<ValuesRequired>> GetValuesAsync()
        {
            try
            {
                return await Task.FromResult(Enum.GetNames(typeof(EnumValuesRequired)).Select(rec=> new ValuesRequired { Id=rec, Name=rec }));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<int> UploadFile(IFormFile file, int? userId)
        {
            int isSaveSuccess = -1;
            string fileName;
            try
            {
                string wwwRootPath = this._ihostenv.WebRootPath;
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;
                var path = Path.Combine(wwwRootPath, "FileUpload");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var finalpath = Path.Combine(wwwRootPath, "FileUpload", fileName);
                using (var stream = new FileStream(finalpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                TblUploadFile upload = new();
                upload.UserId = userId;
                upload.FileName = fileName;
                upload.FileType = file.ContentType;
                upload.FileExtension = extension;
                upload.FilePath = finalpath;
                upload.FileStatus = "NewUserRegistration";
                upload.CreatedDate = DateTime.Now;
                _context.tblUploadFile.Add(upload);
                isSaveSuccess = await _context.SaveChangesAsync();
                //isSaveSuccess = true;
                isSaveSuccess = upload.Id;
                return isSaveSuccess;
            }
            catch (Exception ex)
            {
                return isSaveSuccess;
                //throw;
            }
        }
    }
}
