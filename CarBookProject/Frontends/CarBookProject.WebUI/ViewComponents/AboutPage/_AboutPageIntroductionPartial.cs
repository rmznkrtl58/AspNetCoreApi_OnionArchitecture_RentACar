using CarBookProject.DTOs.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CarBookProject.WebUI.ViewComponents.AboutPage
{
    public class _AboutPageIntroductionPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutPageIntroductionPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Abouts");

			if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetAboutShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        } 
    }
}
