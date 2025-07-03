using CarBookProject.DTOs.DTOs.LoginDTOs;
using CarBookProject.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminLoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminLoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ResultLoginDTO l)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(l);
            StringContent sContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/SignIn", sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JWTResponseModel>(values, new JsonSerializerOptions
                {
                    PropertyNamingPolicy=JsonNamingPolicy.CamelCase
                });
                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler= new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("accessToken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true,
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
    }
}
