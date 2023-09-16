using SLN7.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.IService
{
    public interface ILeadSource
    {
        Task<List<LeadSourceViewModel>> GetAllLeadSource();
        Task<int> AddLeadSource(LeadSourceViewModel model);
        Task<List<LeadSourceViewModel>> GetLeadSourceById(int Id);
        Task<int> UpdateLeadSource(int Id,LeadSourceViewModel model);
        Task<int> DeleteLeadSource(int Id);
    }
}
