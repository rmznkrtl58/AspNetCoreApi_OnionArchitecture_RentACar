using CarBookProject.DTOs.DTOs.CarPricingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "Vasıtalar";
            ViewBag.i3 = "Arabalar";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/CarPricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCarPricingWithCarsShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
        public async Task<IActionResult> CarDetails(int id)
        {
			ViewBag.i1 = "GİRİŞ";
			ViewBag.i2 = "Araba";
			ViewBag.i3 = "Araba Detayları";
			ViewBag.cId = id;
            return View();
        }
    }
}
