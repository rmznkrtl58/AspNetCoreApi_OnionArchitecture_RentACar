using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "HİZMETLERİMİZ";
            ViewBag.i3 = "Verdiğimiz Hizmetler";
            return View();
        }
    }
}
