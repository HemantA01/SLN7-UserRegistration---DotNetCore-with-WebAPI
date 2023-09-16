using SLN7.MODEL.ViewModel;

namespace SLN7.UI.Interface
{
    public interface ILeadSource
    {
        Task<List<LeadSourceViewModel>> GetAllLeadSource();
        Task<int> InsertLeadSource(LeadSourceViewModel model);
        Task<int> AddLeads(LeadSourceViewModel model);
        Task<int> UpdateLeadSource(int Id,LeadSourceViewModel model);
        Task<int> DeleteLeadSource(int Id);
    }
}
