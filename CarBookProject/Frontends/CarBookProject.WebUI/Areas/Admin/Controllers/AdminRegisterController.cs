using CarBookProject.DTOs.DTOs.RegisterDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminRegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public AdminRegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDTO r)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(r);
			StringContent sContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7014/api/Registers", sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminLogin");
			}
			return View();
		}
	}
}
