using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWeb.Controllers
{
    public class UnterhaltungController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Snake()
        {
            return View();
        }
    }
}
