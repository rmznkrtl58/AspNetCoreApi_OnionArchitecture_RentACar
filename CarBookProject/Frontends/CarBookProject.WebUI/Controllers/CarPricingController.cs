using CarBookProject.DTOs.DTOs.CarPricingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
			ViewBag.i1 = "GİRİŞ";
			ViewBag.i2 = "FİYATLANDIRMA";
			ViewBag.i3 = "Araba Fiyatları";
			var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/CarPricings/GetCarPricingWithTimePeriod");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCarPricingWithTimePeriodShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
