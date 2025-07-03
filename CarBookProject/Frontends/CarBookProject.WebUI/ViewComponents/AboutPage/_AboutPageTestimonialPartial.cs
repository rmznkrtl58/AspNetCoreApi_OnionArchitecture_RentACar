using CarBookProject.DTOs.DTOs.TestimonialDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.AboutPage
{
    public class _AboutPageTestimonialPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AboutPageTestimonialPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetTestimonialShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
