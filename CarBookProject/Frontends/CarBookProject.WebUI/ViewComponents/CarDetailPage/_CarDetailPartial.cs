using CarBookProject.DTOs.DTOs.CarDescriptionDTOs;
using CarBookProject.DTOs.DTOs.CarFeatureDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.CarDetailPage
{   //
	public class _CarDetailPartial:ViewComponent
	{
		private readonly IHttpClientFactory _HttpClientFactory;
		public _CarDetailPartial(IHttpClientFactory httpClientFactory)
		{
			_HttpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _HttpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7014/api/CarDescriptions?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var values = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<GetCarDescriptionByCarIdShowcaseDTO>(values);
				return View(jsonData);
			}
			return View();
		}
	}
}
