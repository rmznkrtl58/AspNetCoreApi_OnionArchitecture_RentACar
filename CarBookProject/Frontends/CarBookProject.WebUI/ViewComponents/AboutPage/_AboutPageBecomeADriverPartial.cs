using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.AboutPage
{
	public class _AboutPageBecomeADriverPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
