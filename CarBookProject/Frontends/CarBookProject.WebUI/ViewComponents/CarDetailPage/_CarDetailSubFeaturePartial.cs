using CarBookProject.DTOs.DTOs.CarDTOs;
using CarBookProject.DTOs.DTOs.CarFeatureDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookProject.WebUI.ViewComponents.CarDetailPage
{
	public class _CarDetailSubFeaturePartial : ViewComponent
	{
        private readonly IHttpClientFactory _HttpClientFactory;
        public _CarDetailSubFeaturePartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/CarFeatures/GetCarFeatureByCarId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCarFeatureByCarIdShowcaseDTO>>(values);
                return View(jsonData);
            }
            return View();
        }
        }
	
	}

