using CarBookProject.DTOs.DTOs.FooterDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookProject.WebUI.ViewComponents.ContactPage
{
    public class _ContactPagePartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ContactPagePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Footers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetFooterShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
