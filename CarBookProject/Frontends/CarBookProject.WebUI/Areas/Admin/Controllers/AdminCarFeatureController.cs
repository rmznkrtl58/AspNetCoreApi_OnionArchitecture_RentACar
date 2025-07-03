using CarBookProject.DTOs.DTOs.CarFeatureDTOs;
using CarBookProject.DTOs.DTOs.FeatureDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminCarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/CarFeatures/GetCarFeatureByCarId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                ViewBag.cId = id;
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCarFeatureByCarIdAdminDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
        public async Task<IActionResult> ActiveCarFeature(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/CarFeatures/ActiveCarFeature?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar");
            }
            return View("Index");
        }
        public async Task<IActionResult> PassiveCarFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/CarFeatures/PassiveCarFeature?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar");
            }
            return View("Index");
        }
        [HttpGet]
        public async Task<IActionResult> CreateCarFeature(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetFeatureAdminDTO>>(values);
                List<SelectListItem> features = (from x in jsonData
                                                 select new SelectListItem()
                                                 {
                                                     Text = x.Name,
                                                     Value = x.FeatureId.ToString()
                                                 }).ToList();
                ViewBag.feature = features;
                TempData["cId"] = id;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureDTO c)
        {
            var client = _httpClientFactory.CreateClient();
           
            c.Available = false;
            var jsonData=JsonConvert.SerializeObject(c);
            StringContent sContent = new StringContent(jsonData, Encoding.UTF8, "application/java");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/CarFeatures", sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","AdminCar");
            }
            return View();
        }
    }
}


//[HttpPost]
//public async Task<IActionResult> Index(List<GetCarFeatureByCarIdAdminDTO> resultCarFeatureByCarIdDto)
//{
//    //Check boxlu kullanım Araba özelliği seçme işlemi
//    foreach (var item in resultCarFeatureByCarIdDto)
//    {
//        if (item.Available)
//        {
//            var client = _httpClientFactory.CreateClient();
//            await client.GetAsync("https://localhost:7060/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureId);

//        }
//        else
//        {
//            var client = _httpClientFactory.CreateClient();
//            await client.GetAsync("https://localhost:7060/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureId);
//        }
//    }
//    return RedirectToAction("Index", "AdminCar");
//}