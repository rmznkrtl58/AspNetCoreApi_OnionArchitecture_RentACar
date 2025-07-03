using CarBookProject.DTOs.DTOs.RentACarDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "Arabalar";
            ViewBag.i3 = "Müsait Olanlar";
            id =  Convert.ToInt16(TempData["picklocation"]);
            ViewBag.pickdate = TempData["pickdate"];
            ViewBag.offdate = TempData["offdate"];
            ViewBag.picktime = TempData["picktime"];
            ViewBag.offtime = TempData["offtime"];
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7014/api/RentACars?LocationId={id}&AvailableStatus=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData=JsonConvert.DeserializeObject<List<FilterRentACarDTO>>(values);
                return View(jsonData);
                
            }
            return View();
        }
    }
}
