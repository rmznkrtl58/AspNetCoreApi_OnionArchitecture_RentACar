using CarBookProject.DTOs.DTOs.BlogDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.BlogPage
{
    public class _BlogPageLast3BlogPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogPageLast3BlogPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Blogs/GetLast3BlogWithAuthors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetLast3BlogWithAuthorShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
    }

