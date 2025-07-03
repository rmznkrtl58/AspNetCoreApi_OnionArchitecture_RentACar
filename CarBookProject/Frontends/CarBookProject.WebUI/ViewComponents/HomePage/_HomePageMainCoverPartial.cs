using CarBookProject.DTOs.DTOs.BannerDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.HomePage
{
    public class _HomePageMainCoverPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomePageMainCoverPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetBannerShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
