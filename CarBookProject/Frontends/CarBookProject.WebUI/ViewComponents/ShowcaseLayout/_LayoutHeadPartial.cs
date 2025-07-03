using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.ShowcaseLayout
{
    public class _LayoutHeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
