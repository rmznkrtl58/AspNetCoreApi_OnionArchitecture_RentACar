using CarBookProject.DTOs.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.ServicePage
{
    public class _ServicePageOurLatestServicesPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ServicePageOurLatestServicesPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values= await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetServiceShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
