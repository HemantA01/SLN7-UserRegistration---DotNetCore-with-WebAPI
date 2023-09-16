using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.UI.Interface;

namespace SLN7.UI.Controllers
{
    public class LeadSourceController : Controller
    {
        private readonly ILeadSource _lead;
        public LeadSourceController(ILeadSource lead)
        {
            _lead = lead;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var details = await _lead.GetAllLeadSource();
            return View(details);
        }
        [HttpPost]
        public async Task<JsonResult> AddLeadSource(LeadSourceViewModel model)
        {
           // return null;
            var details = await _lead.InsertLeadSource(model);
            return Json(details);
        }
        [HttpPut]
        public async Task<JsonResult> UpdateLeadSource(int LeadSrcId, LeadSourceViewModel model)
        {
            var details = await _lead.UpdateLeadSource(LeadSrcId,model);
            return Json(details);
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteLeadSource(int LeadSrcId)
        {
            var details = await _lead.DeleteLeadSource(LeadSrcId);
            return Json(details);
        }
    }
}
