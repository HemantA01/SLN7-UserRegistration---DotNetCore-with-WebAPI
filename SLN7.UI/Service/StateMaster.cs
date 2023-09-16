using Microsoft.EntityFrameworkCore;
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
    public class StateMaster: IStateMaster
    {
        private readonly ApplicationContext _context;
        private readonly HelpersApi aPIHelper;
        
        public StateMaster(ApplicationContext context)
        {
            _context = context;
            aPIHelper = new HelpersApi();
        }
        public async Task<CountryStateViewModel> GetStates()
        {
            try
            {
                CountryStateViewModel employees = new CountryStateViewModel();
                var client = aPIHelper.Initial();
                var response = await client.GetAsync("api/StateMaster/GetStateList");
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    employees = JsonConvert.DeserializeObject<CountryStateViewModel>(await response.Content.ReadAsStringAsync());
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

        #region Add states
        public async Task<int> AddStates(StateMasterViewModel model)
        {
            try
            {
                int? getStatus = 0;
                StateMasterViewModel employees = new StateMasterViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/StateMaster/AddStates", requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    getStatus = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return (int)getStatus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update states
        public async Task<int> UpdateStates(StateMasterViewModel model, int Id)
        {
            try
            {
                int? getStatus = 0;
                StateMasterViewModel employees = new StateMasterViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("api/StateMaster/UpdateStates?Id="+Id+ "&CountryId="+model.CountryId, requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    getStatus = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return (int)getStatus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Delete states
        public async Task<int> DeleteStates(int Id)
        {
            try
            {
                int? getStatus = 0;
                StateMasterViewModel employees = new StateMasterViewModel();
                var client = aPIHelper.Initial();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.DeleteAsync("api/StateMaster/DeleteState?Id=" + Id);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    getStatus = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return (int)getStatus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
