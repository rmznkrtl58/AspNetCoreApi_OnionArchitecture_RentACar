using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.ShowcaseLayout
{
    public class _LayoutMainCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
