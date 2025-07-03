using CarBookProject.DTOs.DTOs.BlogDTOs;
using CarBookProject.DTOs.DTOs.CarPricingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.ViewComponents.AdminDashboard
{
    public class Last5BlogListAdminPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Last5BlogListAdminPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Blogs/GetLast5Blog");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetLast5BlogDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}