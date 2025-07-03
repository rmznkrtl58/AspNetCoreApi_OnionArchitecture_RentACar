using CarBookProject.DTOs.DTOs.CarPricingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.ViewComponents.AdminDashboard
{
    public class CarPricingListAdminPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarPricingListAdminPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/CarPricings/GetCarPricingWithTimePeriod");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values= await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCarPricingWithTimePeriodAdminDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
