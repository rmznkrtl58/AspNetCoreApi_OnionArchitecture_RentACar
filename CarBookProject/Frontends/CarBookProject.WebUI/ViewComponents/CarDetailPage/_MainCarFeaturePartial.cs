using CarBookProject.DTOs.DTOs.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.CarDetailPage
{
	public class _MainCarFeaturePartial : ViewComponent
	{
		private readonly IHttpClientFactory _HttpClientFactory;
		public _MainCarFeaturePartial(IHttpClientFactory httpClientFactory)
		{
			_HttpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _HttpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7014/api/Cars/GetCarWithBrandByCarId/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var values=await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<GetCarWithBrandsShowcaseDTO>(values);
				return View(jsonData);
			}
			return View();
		}
	}
	
	}

