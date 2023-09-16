using Newtonsoft.Json;
using SLN7.DATA.DBContext;
using SLN7.MODEL.ViewModel;
using SLN7.UI.Helpers;
using SLN7.UI.Interface;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SLN7.UI.Service
{
    public class UserRegistration : IUserRegistration
    {
        private readonly ApplicationContext _context;
        private readonly HelpersApi aPIHelper;
        public UserRegistration(ApplicationContext context)
        {
            _context=context;
            aPIHelper=new HelpersApi();
        }
        public async Task<int> NewUserRegistration(UserRegistrationViewModel model)
        {
            try
            {
                int? getstatus = 0;
                UserRegistrationViewModel country = new UserRegistrationViewModel();
                var client = aPIHelper.Initial();
                if (model.ProfileImage == null)
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var company = System.Text.Json.JsonSerializer.Serialize(model);
                    var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("api/UserRegistration/RegisterNewUser", requestContent);
                    var result1 = response.Content.ReadAsStringAsync().Result;
                    var content = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        getstatus = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
                else {
                    var filePath = Path.GetTempFileName();
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await model.ProfileImage.CopyToAsync(stream);
                    }
                    HttpClientHandler clientHandler = new HttpClientHandler();
                    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                    var request = new HttpRequestMessage(HttpMethod.Post, "/api/UserRegistration/RegisterNewUser");
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(model.Id.ToString()), "id");
                    content.Add(new StringContent(model.UserId.ToString()), "userId");
                    content.Add(new StringContent(model.UserFname.ToString()), "userFname");
                    content.Add(new StringContent(model.UserLname.ToString()), "userLname");
                    content.Add(new StringContent(model.UserContact.ToString()), "userContact");
                    content.Add(new StringContent(model.UserEmail.ToString()), "userEmail");
                    content.Add(new StringContent(model.DOB.ToString()), "dob");
                    content.Add(new StringContent(model.Age.ToString()), "age");
                    content.Add(new StringContent(model.Gender.ToString()), "gender");
                    content.Add(new StringContent(model.Nationality.ToString()), "nationality");
                    content.Add(new StringContent(model.TemporaryAddress.ToString()), "temporaryAddress");
                    content.Add(new StringContent(model.PermanentAddress.ToString()), "permanentAddress");
                    content.Add(new StringContent(model.CountryId.ToString()), "countryId");
                    content.Add(new StringContent(model.StateId.ToString()), "stateId");
                    content.Add(new StringContent(model.City.ToString()), "city");
                    //content.Add(new StringContent(model.Id.ToString()), "id");
                    content.Add(new StreamContent(File.OpenRead(filePath)), "ProfileImage", model.ProfileImage.FileName);

                    request.Content = content;
                    var response = await client.SendAsync(request);
                    var contentRes = await response.Content.ReadAsStringAsync();
                    var result1 = response.Content.ReadAsStringAsync().Result;
                    var contentRes1 = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        getstatus = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }

                return (int)getstatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserRegistrationControlsViewModel> GetCountriesStatesList()
        {
            try
            {
                UserRegistrationControlsViewModel model = new UserRegistrationControlsViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/UserRegistration/GetCountryStates");
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    model = JsonConvert.DeserializeObject<UserRegistrationControlsViewModel>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UserRegistrationViewModel>> GetUserRegisterList()
        {
            try
            {
                List<UserRegistrationViewModel> model = new List<UserRegistrationViewModel>();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/UserRegistration/GetUsers");
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    model = JsonConvert.DeserializeObject<List<UserRegistrationViewModel>>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async  Task<UserRegistrationControlsViewModel> GetParticularUserById(int userId)
        {
            try
            {
                UserRegistrationControlsViewModel model = new UserRegistrationControlsViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/UserRegistration/GetUsersWithId?userId=" + userId);
                var result1 =  response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    model = JsonConvert.DeserializeObject<UserRegistrationControlsViewModel>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return model;
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
                int? getStatus = 0;
                UserRegistrationControlsViewModel updateUsers = new UserRegistrationControlsViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("api/UserRegistration/UpdateUserDetails?userId=" + userId, requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    getStatus = JsonConvert.DeserializeObject<int?>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return getStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
