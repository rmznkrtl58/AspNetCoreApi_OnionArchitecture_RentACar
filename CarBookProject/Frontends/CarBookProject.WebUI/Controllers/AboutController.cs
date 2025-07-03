using CarBookProject.DTOs.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "Hakkımızda";
            ViewBag.i3 = "Vizyonumuz & Misyonumuz";
            return View();
        }
    }
}
