using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HeadPartial()
        {
            return View();
        }
        public IActionResult ScriptPartial()
        {
            return View();
        }
        public IActionResult FooterPartial()
        {
            return View();
        }
        public IActionResult SidebarPartial()
        {
            return View();
        }
        public IActionResult NavbarPartial()
        {
            return View();
        }
    }
}
