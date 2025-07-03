using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Areas.Admin.ViewComponents.AdminDashboard
{
    public class AdminDashboardScriptPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
