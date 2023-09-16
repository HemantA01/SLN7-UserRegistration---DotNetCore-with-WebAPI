using Microsoft.EntityFrameworkCore;
using SLN7.DATA.DBContext;
using SLN7.MODEL.ViewModel;
using SLN7.UI.Interface;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SLN7.UI.Helpers;
using System.Net;
using System.Text;
using System.Text.Json;
using SLN7.DATA.DBModel;

namespace SLN7.UI.Service
{
    public class UserDetails:IUserDetails
    {
        private readonly ApplicationContext _context;
        private readonly HelpersApi aPIHelper;
        public UserDetails(ApplicationContext context)
        {
            _context = context;
            this.aPIHelper = new HelpersApi();
        }
        public async Task<UserLoginViewModel> UserLogin(UserLoginViewModel model)
        {
            try
            {
                UserLoginViewModel userLoginResult = new UserLoginViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/UserDetails/VerifyUserExistence", requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    userLoginResult = JsonConvert.DeserializeObject<UserLoginViewModel>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }

                return userLoginResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Employee>> GetAllEmp()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                var client = aPIHelper.Initial();

                //var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
                //var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.GetAsync("api/UserDetails/getallemployees");
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    employees = JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }

                return employees;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}


/*public static async Task<T> Get(string url)
{
    T result = null;
    using (var httpClient = new HttpClient())
    {
        var response = httpClient.GetAsync(new Uri(url)).Result;

        response.EnsureSuccessStatusCode();
        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        {
            if (x.IsFaulted)
                throw x.Exception;

            result = JsonConvert.DeserializeObject<T>(x.Result);
        });
    }

    return result;
}*/