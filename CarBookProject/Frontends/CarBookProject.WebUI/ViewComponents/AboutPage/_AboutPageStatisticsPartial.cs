using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.AboutPage
{
    public class _AboutPageStatisticsPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
