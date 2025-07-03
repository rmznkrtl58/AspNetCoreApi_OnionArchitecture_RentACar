using CarBookProject.DTOs.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _HttpClientFactory;
        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetContactListAdminDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
        public async Task<IActionResult> ContactDetails(int id)
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Contacts/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var value = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<GetContactAdminDTO>(value);
                return View(jsonData);
            }
            return View();
        }
    }
}
