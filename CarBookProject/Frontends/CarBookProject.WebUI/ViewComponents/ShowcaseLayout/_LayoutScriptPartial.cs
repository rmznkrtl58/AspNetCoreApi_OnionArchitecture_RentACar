using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.ShowcaseLayout
{
    public class _LayoutScriptPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
