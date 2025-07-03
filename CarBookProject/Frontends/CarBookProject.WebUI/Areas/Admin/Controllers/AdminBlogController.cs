using CarBookProject.DTOs.DTOs.AuthorDTOs;
using CarBookProject.DTOs.DTOs.BlogDTOs;
using CarBookProject.DTOs.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:7014/api/Blogs/GetBlogsWithCategoryAndAuthor");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var values = await responseMessage.Content.ReadAsStringAsync();
                    var jsonData = JsonConvert.DeserializeObject<List<GetBlogsWithAuthorAndCategoryAdminDTO>>(values);
                    return View(jsonData);
                }
        }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCategoryAdminDTO>>(values);
                //dropdown liste kategorileri getirme
                List<SelectListItem> categoryList = (from x in jsonData
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.CategoryId.ToString()
                                                     }).ToList();
                ViewBag.categoryList = categoryList;

                var responseMessage2 = await client.GetAsync("https://localhost:7014/api/Authors");
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var values2=await responseMessage2.Content.ReadAsStringAsync();
                    var jsonData2 = JsonConvert.DeserializeObject<List<GetAuthorAdminDTO>>(values2);
                    //dropdown liste Yazarları getirme
                    List<SelectListItem> authorList = (from x in jsonData2
                                                       select new SelectListItem
                                                       {
                                                           Text=x.NameSurname,
                                                           Value = x.AuthorId.ToString()
                                                       }).ToList();
                    ViewBag.authorList = authorList;
                }
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogAdminDTO c)
        {
            c.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(c);
            StringContent sContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/Blogs", sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7014/api/Blogs/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCategoryAdminDTO>>(values);
                //dropdown liste kategorileri getirme
                List<SelectListItem> categoryList = (from x in jsonData
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.CategoryId.ToString()
                                                     }).ToList();
                ViewBag.categoryList = categoryList;

                var responseMessage2 = await client.GetAsync("https://localhost:7014/api/Authors");
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var values2 = await responseMessage2.Content.ReadAsStringAsync();
                    var jsonData2 = JsonConvert.DeserializeObject<List<GetAuthorAdminDTO>>(values2);
                    //dropdown liste Yazarları getirme
                    List<SelectListItem> authorList = (from x in jsonData2
                                                       select new SelectListItem
                                                       {
                                                           Text = x.NameSurname,
                                                           Value = x.AuthorId.ToString()
                                                       }).ToList();
                    ViewBag.authorList = authorList;
                    var responseMessage3 = await client.GetAsync("https://localhost:7014/api/Blogs/" + id);
                    if (responseMessage3.IsSuccessStatusCode)
                    {
                        var values3 = await responseMessage3.Content.ReadAsStringAsync();
                        var jsonData3 = JsonConvert.DeserializeObject<UpdateBlogAdminDTO>(values3);
                        return View(jsonData3);
                    }
                    return View();
                }
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogAdminDTO c)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(c);
            StringContent sContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7014/api/Blogs", sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
