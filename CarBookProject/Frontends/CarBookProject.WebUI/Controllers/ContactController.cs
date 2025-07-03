using CarBookProject.DTOs.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactShowcaseDTO c)
        {
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "İletişim";
            ViewBag.i3 = "İletişim Bilgileri";
            var client=_httpClientFactory.CreateClient();
            c.SendDate = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(c);
            StringContent sContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/Contacts",sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(c);
        }
    }
}
