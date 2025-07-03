using CarBookProject.DTOs.DTOs.LocationDTOs;
using CarBookProject.DTOs.DTOs.RentACarDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarBookProject.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "Ana Sayfa";
            ViewBag.i3 = "Girizgah";
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:7014/api/Locations");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var values = await responseMessage.Content.ReadAsStringAsync();
                    var jsonData = JsonConvert.DeserializeObject<List<GetLocationShowcaseDTO>>(values);
                    List<SelectListItem> locationList = (from x in jsonData
                                                         select new SelectListItem
                                                         {
                                                             Text = x.PointName,
                                                             Value = x.LocationId.ToString()
                                                         }).ToList();
                    ViewBag.dropDownLocation = locationList;
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string pickdate,string offdate,string picktime,string offtime,int LocationId)
        {
            TempData["pickdate"] = pickdate;
            TempData["offdate"] = offdate;
            TempData["picktime"] = picktime;
            TempData["offtime"] = offtime;
            TempData["picklocation"] = LocationId;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}
