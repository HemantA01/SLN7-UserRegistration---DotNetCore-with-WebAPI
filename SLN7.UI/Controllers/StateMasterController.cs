using Microsoft.AspNetCore.Mvc;
using SLN7.MODEL.ViewModel;
using SLN7.UI.Interface;

namespace SLN7.UI.Controllers
{
    public class StateMasterController : Controller
    {
        private readonly IStateMaster _istate;
        public StateMasterController(IStateMaster istate)
        {
            _istate = istate;
        }
        [HttpGet]
        public async Task<IActionResult> GetStatesList()
        {
            try
            {
                CountryStateViewModel model = new CountryStateViewModel();
                model = await _istate.GetStates();
                
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<JsonResult> AddStates(StateMasterViewModel model)
        {
            try
            {
                int? getStatus = -1;
                getStatus = await _istate.AddStates(model);
                return Json(getStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        public async Task<JsonResult> UpdateStates(int Id, StateMasterViewModel model)
        {
            try
            {
                int? getStatus = -1;
                getStatus = await _istate.UpdateStates(model,Id);
                return Json(getStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteStates(int Id)
        {
            try
            {
                int? getStatus = -1;
                getStatus = await _istate.DeleteStates(Id);
                return Json(getStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

/*
 public ActionResult A()
{
TempData["name"] = "Update";
}
public ActionResult B()
{
string getname;
if (TempData.ContainsKey("name"))
    getname = TempData["name"].ToString();
}
 */
