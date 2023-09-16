using Microsoft.EntityFrameworkCore;
using SLN7.DATA.DBContext;
using SLN7.DATA.DBModel;
using SLN7.MODEL.Logger;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.Service
{
    public class CountryMaster : ICountryMaster
    {
        private readonly ApplicationContext _appContext;
        public CountryMaster(ApplicationContext appContext)
        {
            _appContext = appContext;
        }
        /// <summary>
        /// Get List of Countries
        /// </summary>
        /// <returns></returns>
        #region Get List Of Countries
        public async Task<List<CountryMasterViewModel>> GetAllCountries()
        {
            try
            {
                var getList = await _appContext.tblCountryMaster.Select(x => new CountryMasterViewModel
                {
                    Id = x.Id,
                    CountryName = x.CountryName,
                    CountryAbb = x.CountryAbb,
                    IsCountryActive = x.IsActive == true ? "Active" : "Inactive"
                }).ToListAsync();
                return getList;
            }
            catch (Exception ex)
            {
                GenerateLog.WriteLog(ex.Message);
                throw;
            }
        }
        #endregion

        #region Add Countries
        public async Task<int> AddCountries(CountryMasterViewModel model)
        {
            try
            {
                int i = -1;
                var ifExists = await _appContext.tblCountryMaster.Where(x => x.CountryName == model.CountryName).FirstOrDefaultAsync();
                if (ifExists == null)
                {
                    TblCountryMaster addcountry = new TblCountryMaster();
                    addcountry.CountryName = model.CountryName.ToUpper();
                    addcountry.CountryAbb = model.CountryAbb.ToUpper();
                    addcountry.IsActive = true;
                    _appContext.tblCountryMaster.Add(addcountry);
                    i = await _appContext.SaveChangesAsync();
                }
                else
                {
                    i = -2;
                }
                return i;
            }
            catch (Exception ex)
            {
                GenerateLog.WriteLog(ex.Message);
                throw;
            }
        }
        #endregion

        #region Update Country Details
        public async Task<int> UpdateCountry(int Id, CountryMasterViewModel model)
        {
            try
            {
                int i = -1;
                var ifExists = await _appContext.tblCountryMaster.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    if (ifExists.CountryName.Trim().ToLower() == model.CountryName.Trim().ToLower() && ifExists.IsActive == model.IsActive && ifExists.CountryAbb.Trim().ToLower() == model.CountryAbb.Trim().ToLower())
                    {
                        i = 2;
                    }
                    else
                    {
                        ifExists.CountryName = model.CountryName;
                        ifExists.CountryAbb = model.CountryAbb;
                        ifExists.IsActive = model.IsActive;
                        i = await _appContext.SaveChangesAsync();
                    }
                }
                else
                {
                    i = -2;
                }
                return i;
            }
            catch (Exception ex)
            {
                GenerateLog.WriteLog(ex.Message);
                throw;
            }
        }
        #endregion

        #region Delete country based on Id
        public async Task<int> DeleteCountry(int Id)
        {
            try
            {
                int i = -1;
                var ifExists = await _appContext.tblCountryMaster.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    _appContext.tblCountryMaster.Remove(ifExists);
                    i = await _appContext.SaveChangesAsync();
                }
                return i;
            }
            catch (Exception ex)
            {
                GenerateLog.WriteLog(ex.Message);
                throw;
            }
        }
        #endregion
    }
}
