using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.ShowcaseLayout
{
    public class _LayoutNavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
