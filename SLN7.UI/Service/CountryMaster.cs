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
    public class CountryMaster : ICountryMaster
    {
        private readonly ApplicationContext _context;
        private readonly HelpersApi aPIHelper;
        public CountryMaster(ApplicationContext context)
        {
            _context=context;
            this.aPIHelper = new HelpersApi();
        }

        public async Task<List<CountryMasterViewModel>> GetAllCountries()
        {
            try
            {
                List<CountryMasterViewModel> employees = new List<CountryMasterViewModel>();
                var client = aPIHelper.Initial();
                var response = await client.GetAsync("api/CountryMaster/GetAllCountries");
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    employees = JsonConvert.DeserializeObject<List<CountryMasterViewModel>>(await response.Content.ReadAsStringAsync());
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

        public async Task<int> AddCountries(CountryMasterViewModel model)
        {
            try
            {
                int? getstatus = 0;
                CountryMasterViewModel country = new CountryMasterViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/CountryMaster/AddCountry", requestContent);
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateCountries(int Id,CountryMasterViewModel model)
        {
            try
            {
                int? getstatus = 0;
                CountryMasterViewModel country = new CountryMasterViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("api/CountryMaster/UpdateCountryDetails?Id=" + Id, requestContent);
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteCountries(int Id)
        {
            try
            {
                int? getstatus = 0;
                CountryMasterViewModel country = new CountryMasterViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.DeleteAsync("api/CountryMaster/DeleteCountry?Id=" + Id);
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
