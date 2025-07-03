using CarBookProject.DTOs.DTOs.BlogDTOs;
using CarBookProject.DTOs.DTOs.CommentDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    public class BlogController1 : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController1(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "Bloglar";
            ViewBag.i3 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Blogs/GetBlogsWithCategoryAndAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetBlogsWithCategoryAndAuthorShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.i1 = "GİRİŞ";
            ViewBag.i2 = "Bloglar";
            ViewBag.i3 = "Blog İçeriği";
            ViewBag.blogId=id;
            TempData["bId"] = id;
            return View();
        }
        [HttpGet]
        public async Task<PartialViewResult> _LeaveACommentPartial()
        {
        
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult>LeaveAComment(CreateCommentShowcaseDTO c)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(c);
            StringContent sContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/Comments",sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

    }
}
