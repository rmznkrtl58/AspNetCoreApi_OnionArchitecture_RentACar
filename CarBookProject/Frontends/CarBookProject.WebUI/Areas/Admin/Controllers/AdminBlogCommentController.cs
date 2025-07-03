using CarBookProject.DTOs.DTOs.CommentDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminBlogCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminBlogCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //İlgili bloğa göre yorumları listele 
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Comments/GetCommentByBlogId/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCommentByBlogIdAdminDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
