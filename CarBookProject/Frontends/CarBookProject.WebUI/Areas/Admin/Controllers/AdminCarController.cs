using CarBookProject.DTOs.DTOs.BrandDTOs;
using CarBookProject.DTOs.DTOs.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _htttpClientFactory;
        public AdminCarController(IHttpClientFactory htttpClientFactory)
        {
            _htttpClientFactory = htttpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _htttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Cars/GetCarListWithBrands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCarWithBrandsAdminDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client=_htttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetBrandAdminDTO>>(values);
                List<SelectListItem> brands = (from x in jsonData
                                               select new SelectListItem
                                               {
                                                   Text=x.Name,
                                                   Value=x.BrandId.ToString()
                                               }).ToList();
                ViewBag.brands= brands;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarAdminDTO c)
        {
            var client = _htttpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(c);
            StringContent sContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/Cars", sContent);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index","AdminCar");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _htttpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7014/api/Cars/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client=_htttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetBrandAdminDTO>>(values);
                //dropdownliste getirme
                List<SelectListItem> brandList = (from x in jsonData
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.BrandId.ToString()
                                                  }).ToList();
                ViewBag.Brands = brandList;
                var responseMessage2 = await client.GetAsync("https://localhost:7014/api/Cars/GetCarWithBrandByCarId/" + id);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var values2 = await responseMessage2.Content.ReadAsStringAsync();
                    var jsonData2 = JsonConvert.DeserializeObject<GetCarsWithBrandByCarIdAdminDTO>(values2);
                    return View(jsonData2);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarAdminDTO c)
        {
            var client=_htttpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(c);
            StringContent sContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7014/api/Cars",sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
