using SLN7.DATA.DBContext;
using SLN7.UI.Interface;
using SLN7.UI.Helpers;
using SLN7.MODEL.ViewModel;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SLN7.UI.Service
{
    public class LeadSource : ILeadSource
    {
        private readonly ApplicationContext _context;
        private readonly HelpersApi aPIHelper;
        public LeadSource(ApplicationContext context)
        {
            _context=context;
            this.aPIHelper = new HelpersApi();
        }

        public async Task<List<LeadSourceViewModel>> GetAllLeadSource()
        {
            try
            {
                List<LeadSourceViewModel> employees = new List<LeadSourceViewModel>();
                var client = aPIHelper.Initial();
                var response = await client.GetAsync("api/LeadSource/GetAllLeadSource");
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    employees = JsonConvert.DeserializeObject<List<LeadSourceViewModel>>(await response.Content.ReadAsStringAsync());
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

        public async Task<int> InsertLeadSource(LeadSourceViewModel model)
        {
            try
            {
                int? getstatus = 0;
                LeadSourceViewModel leadSourceView = new LeadSourceViewModel();
                var client = aPIHelper.Initial();
                //var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
                //var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                //var response = await client.PostAsJsonAsync("api/LeadSource/AddLeadSource", model);
                ////var response =await client.PostAsync()
                //var result1 = response.Content.ReadAsStringAsync().Result;
                //var content = await response.Content.ReadAsStringAsync();
                //int model = 12;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                //var response = await client.PostAsync("api/LeadSource/AddLeadSourceDetails?aa=12", requestContent);       working
                var response = await client.PostAsync("api/LeadSource/AddLeadSourceDetails", requestContent);
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
                return (int)getstatus;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> AddLeads(LeadSourceViewModel model)
        {
            try
            {
                LeadSourceViewModel userLoginResult = new LeadSourceViewModel();
                UserLoginViewModel model1=new UserLoginViewModel()
                {
                    UserName="hjgfjfhgkj",
                    Password="ghjghj"
                };
                var client = aPIHelper.Initial();
                //client.DefaultRequestHeaders.Accept.Clear();
                //var company = JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var requestContent = new StringContent(model, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await client.PostAsJsonAsync<UserLoginViewModel>("api/UserDetails/VerifyUserExistence", requestContent);



                var company = System.Text.Json.JsonSerializer.Serialize(model1);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PostAsJsonAsync("api/LeadSource/AddLeadSourceDetails", requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //userLoginResult = JsonConvert.DeserializeObject<UserLoginViewModel>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }

                return 5;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateLeadSource(int Id,LeadSourceViewModel model)
        {
            try
            {
                int? getstatus = 0;
                LeadSourceViewModel leadSourceView = new LeadSourceViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("api/LeadSource/UpdateLeadSource?LeadSrcID=" + Id, requestContent);
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
                return (int)getstatus;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> DeleteLeadSource(int Id)
        {
            try
            {
                int? getstatus = 0;
                LeadSourceViewModel leadSourceView = new LeadSourceViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var company = System.Text.Json.JsonSerializer.Serialize(model);
                //var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                //var response = await client.PutAsync("api/LeadSource/UpdateLeadSource?LeadSrcID=" + Id, requestContent);
                var response = await client.DeleteAsync("api/LeadSource/DeleteLeadSource?LeadSrcID=" + Id);
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
                return (int)getstatus;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
