using CarBookProject.DTOs.DTOs.LocationDTOs;
using CarBookProject.DTOs.DTOs.ReservationDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetLocationShowcaseDTO>>(values);
                List<SelectListItem> locationList = (from x in jsonData
                                                     select new SelectListItem
                                                     {
                                                         Text = x.PointName,
                                                         Value = x.LocationId.ToString()
                                                     }).ToList();
                ViewBag.dLocationList = locationList;
                var responseMessage2 = await client.GetAsync("https://localhost:7014/api/Cars/GetCarWithBrandByCarId/" + id);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var values2 = await responseMessage2.Content.ReadAsStringAsync();
                    var jsonData2 = JsonConvert.DeserializeObject<GetReservationByCarIdShowcaseDTO>(values2);
                    ViewData["model"] = jsonData2.Model;
                    ViewData["brand"] = jsonData2.BrandName;
                    ViewData["img"] = jsonData2.CoverImageUrl;
                    ViewData["carId"] = id;
                }
            }
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "Araba Kiralama";
            ViewBag.i3 = "Rezervasyon";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationShowcaseDTO r)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(r);
            StringContent sContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/Reservations",sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
