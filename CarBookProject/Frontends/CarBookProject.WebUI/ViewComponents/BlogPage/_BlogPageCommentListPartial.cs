using CarBookProject.DTOs.DTOs.CommentDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.BlogPage
{
    public class _BlogPageCommentListPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogPageCommentListPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Comments/GetCommentByBlogId/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCommentByBlogIdShowcaseDTO>>(values);
                return View(jsonData);
            }
;            return View();
        }
    }
}
