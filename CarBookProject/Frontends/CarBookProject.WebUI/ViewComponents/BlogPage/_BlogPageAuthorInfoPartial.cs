using CarBookProject.DTOs.DTOs.BlogDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.BlogPage
{
    public class _BlogPageAuthorInfoPartial:ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _BlogPageAuthorInfoPartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client=_HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Blogs/GetBlogByIdWithAuthor/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<GetBlogByIdWithAuthorShowcaseDTO>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
