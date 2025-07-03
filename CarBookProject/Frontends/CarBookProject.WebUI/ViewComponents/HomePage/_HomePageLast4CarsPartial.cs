using CarBookProject.DTOs.DTOs.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.HomePage
{
    public class _HomePageLast4CarsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageLast4CarsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Cars/GetLast4CarsWithBrands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetLast4CarWithBrandsShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
