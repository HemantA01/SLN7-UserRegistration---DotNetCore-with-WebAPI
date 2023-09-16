using Microsoft.EntityFrameworkCore;
using SLN7.DATA.DBContext;
using SLN7.DATA.DBModel;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.Service
{
    public class StateMaster : IStateMaster
    {
        private readonly ApplicationContext _context;
        public StateMaster(ApplicationContext context)
        {
            _context = context;
        }
        #region Retrieve all States
        public async Task<List<CountryStateMasterViewModel>> GetStatesList()
        {
            try
            {
                var getDetails = await (from country in _context.tblCountryMaster
                                        join state in _context.tblStateMaster on country.Id equals state.CountryId
                                        where country.IsActive == true
                                        select new CountryStateMasterViewModel
                                        {
                                            CountryId = country.Id,
                                            CountryName = country.CountryName,
                                            StateId = state.Id,
                                            StateName = state.StateName,
                                            IsStateActive = state.IsActive == true ? "Active" : "Inactive"
                                        }).ToListAsync();
                return getDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Retrieve all countries
        public async Task<List<CountryMasterViewModel>> GetCountriesList()
        {
            try
            {
                var getDetails = await (from country in _context.tblCountryMaster
                                        where country.IsActive == true
                                        select new CountryMasterViewModel
                                        {
                                            Id = country.Id,
                                            CountryName = country.CountryName,
                                        }).ToListAsync();
                return getDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Add State according to countries
        public async Task<int> AddStatesAgainstCountries(StateMasterViewModel model)
        {
            try
            {
                int i = -1;
                var ifExists = await _context.tblStateMaster.Where(x => x.CountryId == model.CountryId && x.StateName == model.StateName).FirstOrDefaultAsync();
                if (ifExists == null)
                {
                    TblStateMaster addstate = new TblStateMaster();
                    addstate.CountryId = model.CountryId;
                    addstate.StateName = model.StateName.ToUpper();
                    addstate.IsActive = true;
                    _context.tblStateMaster.Add(addstate);
                    i = await _context.SaveChangesAsync();
                }
                else
                {
                    i = -2;
                }
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update State according to countries
        public async Task<int> UpdateStates(int Id, int? CountryId, StateMasterViewModel model)
        {
            try
            {
                int i = -1;
                var ifExists = await _context.tblStateMaster.Where(x => x.Id == Id && x.CountryId == CountryId).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    ifExists.CountryId = model.CountryId;
                    ifExists.StateName = model.StateName.ToUpper();
                    ifExists.IsActive = model.IsActive;
                    i = await _context.SaveChangesAsync();
                }
                else
                {
                    i = -2;
                }
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete State from table
        public async Task<int> DeleteState(int Id)
        {
            try
            {
                int i = -1;
                var ifExists = await _context.tblStateMaster.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    _context.tblStateMaster.Remove(ifExists);
                    i = await _context.SaveChangesAsync();
                }
                else
                {
                    i = -2;
                }
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region To get list of state inside country
        public async Task<List<CountryWithStateListViewModel>> GetCountryWithStateList()
        {
            try
            {
                List<CountryWithStateListViewModel> countryWithStateListView = new List<CountryWithStateListViewModel>();

                CountryStateViewModel getdetails = new CountryStateViewModel();
                
                var cntdata = await _context.tblCountryMaster.Where(c => c.IsActive == true).ToListAsync();
                if (cntdata != null)
                {
                    foreach (var item in cntdata)
                    {
                        CountryWithStateListViewModel getcountryMasterViewModel = new CountryWithStateListViewModel();
                        getcountryMasterViewModel.CountryId = item.Id; 
                        getcountryMasterViewModel.CountryName = item.CountryName;
                        getcountryMasterViewModel.CountryAbb = item.CountryAbb;
                        //getdetails.countryMasterViewModel.Add(getcountryMasterViewModel);
                        var getstate = await _context.tblStateMaster.Where(x=>x.CountryId==item.Id).ToListAsync();
                        foreach (var item1 in getstate)
                        {
                            StateMasterViewModel getstateMasterViewModel = new StateMasterViewModel();
                            getstateMasterViewModel.Id = item1.Id;
                            getstateMasterViewModel.StateName = item1.StateName;
                            getstateMasterViewModel.CountryId = item1.CountryId;
                            getcountryMasterViewModel.stateMasterLst.Add(getstateMasterViewModel);
                        }
                        countryWithStateListView.Add(getcountryMasterViewModel);
                    }
                }
                return countryWithStateListView;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
