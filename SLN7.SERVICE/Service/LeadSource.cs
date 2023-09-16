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
    public class LeadSource : ILeadSource
    {
        private readonly ApplicationContext _context;
        public LeadSource(ApplicationContext context)
        {
            _context=context;
        }
        public async Task<List<LeadSourceViewModel>> GetAllLeadSource()
        {
            try
            {
                var getallleadsrc = await _context.tblLeadSource.Select(x => new LeadSourceViewModel()
                {
                    LeadSourceID = x.LeadSourceID,
                    LeadSourceText = x.LeadSourceText,
                    IsLeadSrcActive = x.LeadSourceStatus == true ? "Active" : "Inactive",
                    LeadSourceCreatedDate = x.LeadSourceCreatedOn
                }).ToListAsync();
                return getallleadsrc;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddLeadSource(LeadSourceViewModel model)
        {
            try
            {
                var isLeadExists=await _context.tblLeadSource.Where(x=>x.LeadSourceText==model.LeadSourceText && x.LeadSourceStatus==model.LeadSourceStatus).FirstOrDefaultAsync();
                if (isLeadExists == null)
                {
                    TblLeadSource addleads = new TblLeadSource();
                    addleads.LeadSourceText = model.LeadSourceText;
                    addleads.LeadSourceStatus = model.LeadSourceStatus;
                    addleads.LeadSourceCreatedOn = DateTime.UtcNow;
                    addleads.UserId = 1;
                    _context.tblLeadSource.Add(addleads);
                    _context.SaveChanges();
                    return await Task.FromResult(1);
                }
                return await Task.FromResult(-1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<LeadSourceViewModel>> GetLeadSourceById(int Id)
        {
            try
            {
                var getleadsrcbyid = await _context.tblLeadSource.Where(x=>x.LeadSourceID==Id).Select(x => new LeadSourceViewModel()
                {
                    LeadSourceID = x.LeadSourceID,
                    LeadSourceText = x.LeadSourceText,
                    IsLeadSrcActive = x.LeadSourceStatus == true ? "Active" : "Inactive",
                    LeadSourceCreatedDate = x.LeadSourceCreatedOn
                }).ToListAsync();
                return getleadsrcbyid;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> UpdateLeadSource(int Id, LeadSourceViewModel model)
        {
            try
            {
                //var isLeadExists = await _context.tblLeadSource.Where(x => x.LeadSourceID==model.LeadSourceID).FirstOrDefaultAsync();
                var isLeadExists = await _context.tblLeadSource.Where(x => x.LeadSourceID == Id).FirstOrDefaultAsync();
                if (isLeadExists != null)
                {
                    if (isLeadExists.LeadSourceText.Trim().ToLower() == model.LeadSourceText.Trim().ToLower() && isLeadExists.LeadSourceStatus == model.LeadSourceStatus)
                    {
                        return await Task.FromResult(2);
                    }
                    else
                    {
                        isLeadExists.LeadSourceText=model.LeadSourceText;
                        isLeadExists.LeadSourceStatus=model.LeadSourceStatus;
                        await _context.SaveChangesAsync();
                        return await Task.FromResult(1);
                    }
                }
                return await Task.FromResult(-1);
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
                var isLeadExists = await _context.tblLeadSource.Where(x => x.LeadSourceID == Id).FirstOrDefaultAsync();
                if (isLeadExists != null)
                {
                     _context.tblLeadSource.Remove(isLeadExists);
                    _context.SaveChanges();
                    return await Task.FromResult(1);
                }
                    return await Task.FromResult(-1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
