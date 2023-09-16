using Microsoft.AspNetCore.Mvc;

namespace SLN7.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult DashboardHome()
        {
            return View();
        }
    }
}
