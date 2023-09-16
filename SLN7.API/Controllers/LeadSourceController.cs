using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;

namespace SLN7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadSourceController : ControllerBase
    {
        private readonly ILeadSource _iLeadSrc;
        public LeadSourceController(ILeadSource iLeadSrc)
        {
            _iLeadSrc = iLeadSrc;   
        }

        [HttpGet, Route("GetAllLeadSource")]
        public async Task<List<LeadSourceViewModel>> GetAllLeadSource()
        {
            try
            {
                var details = await _iLeadSrc.GetAllLeadSource();
                return details;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost,Route("AddLeadSourceDetails")]
        //public async Task<IActionResult> AddLeadSource(LeadSourceViewModel model1, int aa)                //working
        public async Task<IActionResult> AddLeadSource(LeadSourceViewModel model1)
        {
            try
            {
                //LeadSourceViewModel model1 = new LeadSourceViewModel();
                var status=await _iLeadSrc.AddLeadSource(model1);
                return Ok(status);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet, Route("GetLeadSourceById")]
        public async Task<List<LeadSourceViewModel>> GetLeadSourceById(int Id)
        {
            try
            {
                var details = await _iLeadSrc.GetLeadSourceById(Id);
                return details;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut, Route("UpdateLeadSource")]
        public async Task<IActionResult> UpdateLeadSource(int LeadSrcID, LeadSourceViewModel model)
        {
            try
            {
                var status = await _iLeadSrc.UpdateLeadSource(LeadSrcID,model);
                return Ok(status);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete, Route("DeleteLeadSource")]
        public async Task<IActionResult> DeleteLeadSource(int LeadSrcID)
        {
            try
            {
                var status = await _iLeadSrc.DeleteLeadSource(LeadSrcID);
                return Ok(status);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
