using CarBookProject.DTOs.DTOs.BlogDTOs;
using CarBookProject.DTOs.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.BlogPage
{
    public class _BlogPageCategoryPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogPageCategoryPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCategoryShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}

