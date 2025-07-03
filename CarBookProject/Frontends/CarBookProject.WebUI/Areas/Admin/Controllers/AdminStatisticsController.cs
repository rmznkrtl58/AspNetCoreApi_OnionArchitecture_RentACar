using CarBookProject.DTOs.DTOs.StatisticsDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            //Car count
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var value=await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<GetStatisticsDTO>(value);
                ViewBag.carCount = jsonData.CarCount;
                //Location Count
                var responseMessage2 = await client.GetAsync("https://localhost:7014/api/Statistics/GetLocationCount");
                if (responseMessage2.IsSuccessStatusCode) 
                {
                  var value2=await responseMessage2.Content.ReadAsStringAsync();
                  var jsonData2 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value2);
                  ViewBag.locationCount = jsonData2.LocationCount;
                    //Author Count
                    var responseMessage3 = await client.GetAsync("https://localhost:7014/api/Statistics/GetAuthorCount");
                    if (responseMessage3.IsSuccessStatusCode)
                    {
                        var value3=await responseMessage3.Content.ReadAsStringAsync();
                        var jsonData3 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value3);
                        ViewBag.authorCount = jsonData3.AuthorCount;
                        //Blog Count
                        var responseMessage4 = await client.GetAsync("https://localhost:7014/api/Statistics/GetBlogCount");
                        if (responseMessage4.IsSuccessStatusCode)
                        {
                            var value4 = await responseMessage4.Content.ReadAsStringAsync();
                            var jsonData4 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value4);
                            ViewBag.blogCount = jsonData4.BlogCount;
                            //Brand Count
                            var responseMessage5 = await client.GetAsync("https://localhost:7014/api/Statistics/GetBrandCount");
                            if (responseMessage5.IsSuccessStatusCode)
                            {
                                var value5 = await responseMessage5.Content.ReadAsStringAsync();
                                var jsonData5 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value5);
                                ViewBag.brandCount = jsonData5.BrandCount;
                                //Avg rent price for daily
                                var responseMessage6 = await client.GetAsync("https://localhost:7014/api/Statistics/GetAvgRentPriceForDaily");
                                if (responseMessage6.IsSuccessStatusCode)
                                {
                                    var value6= await responseMessage6.Content.ReadAsStringAsync();
                                    var jsonData6 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value6);
                                    ViewBag.avgRentPriceForDaily = jsonData6.AvgRentPriceForDaily;
                                    //Avg rent price for Weekly
                                    var responseMessage7 = await client.GetAsync("https://localhost:7014/api/Statistics/GetAvgRentPriceForWeekly");
                                    if (responseMessage7.IsSuccessStatusCode)
                                    {
                                        var value7= await responseMessage7.Content.ReadAsStringAsync();
                                        var jsonData7 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value7);
                                        ViewBag.avgRentPriceForWeekly = jsonData7.AvgRentPriceForWeekly;
                                        //Avg rent price for Monthly
                                        var responseMessage8 = await client.GetAsync("https://localhost:7014/api/Statistics/GetAvgRentPriceForMonthly");
                                        if (responseMessage8.IsSuccessStatusCode)
                                        {
                                            var value8=await responseMessage8.Content.ReadAsStringAsync();
                                            var jsonData8 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value8);
                                            ViewBag.avgRentPriceForMonthly = jsonData8.AvgRentPriceForMonthly;
                                            //Car Count By Transmission Is Auto
                                            var responseMessage9 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCountByTranmissionIsAuto");
                                            if (responseMessage9.IsSuccessStatusCode)
                                            {
                                                var value9=await responseMessage9.Content.ReadAsStringAsync();
                                                var jsonData9=JsonConvert.DeserializeObject<GetStatisticsDTO>(value9);
                                                ViewBag.carCountByTranmissionIsAuto = jsonData9.CarCountByTranmissionIsAuto;
                                            }
                                            //Car Count By Km Smaller Then 30000
                                            var responseMessage10 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCountByKmSmallerThen30000");
                                            if (responseMessage10.IsSuccessStatusCode)
                                            {
                                                var value10 = await responseMessage10.Content.ReadAsStringAsync();
                                                var jsonData10 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value10);
                                                ViewBag.CarCountByKmSmallerThen30000 = jsonData10.CarCountByKmSmallerThen30000;
                                                //Car Count By Fuel Electric
                                                var responseMessage11 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCountByFuelElectric");
                                                if (responseMessage11.IsSuccessStatusCode)
                                                {
                                                    var value11=await responseMessage11.Content.ReadAsStringAsync();
                                                    var jsonData11=JsonConvert.DeserializeObject<GetStatisticsDTO>(value11);
                                                    ViewBag.carCountByFuelElectric = jsonData11.CarCountByFuelElectric;
                                                }
                                                //Car Count By Fuel Diesel
                                                var responseMessage12 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCountByFuelDiesel");
                                                if (responseMessage12.IsSuccessStatusCode)
                                                {
                                                    var value12 = await responseMessage12.Content.ReadAsStringAsync();
                                                    var jsonData12 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value12);
                                                    ViewBag.carCountByFuelDiesel = jsonData12.CarCountByFuelDiesel;
                                                    //CarBrandAndModelByRentPriceDailyMax
                                                    var responseMessage13 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
                                                    if (responseMessage13.IsSuccessStatusCode)
                                                    {
                                                        var value13=await responseMessage13.Content.ReadAsStringAsync();
                                                        var jsonData13=JsonConvert.DeserializeObject<GetStatisticsDTO>(value13);
                                                        ViewBag.carBrandAndModelByRentPriceDailyMax = jsonData13.CarBrandAndModelByRentPriceDailyMax;
                                                        //CarBrandAndModelByRentPriceDailyMin
                                                        var responseMessage14 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
                                                        if (responseMessage14.IsSuccessStatusCode)
                                                        {
                                                            var value14 = await responseMessage14.Content.ReadAsStringAsync();
                                                            var jsonData14 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value14);
                                                            ViewBag.carBrandAndModelByRentPriceDailyMin = jsonData14.CarBrandAndModelByRentPriceDailyMin;
                                                            //BrandNameByMaxCar
                                                            var responseMessage15 = await client.GetAsync("https://localhost:7014/api/Statistics/BrandNameByMaxCar");
                                                            if (responseMessage15.IsSuccessStatusCode) 
                                                            {
                                                                var value15=await responseMessage15.Content.ReadAsStringAsync();
                                                                var jsonData15 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value15);
                                                                ViewBag.BrandNameByMaxCar = jsonData15.BrandNameByMaxCar;
                                                                //BrandNameByMaxCar
                                                                var responseMessage16 = await client.GetAsync("https://localhost:7014/api/Statistics/BlogTitleByMaxBlogComment");
                                                                if (responseMessage16.IsSuccessStatusCode)
                                                                {
                                                                    var value16=await responseMessage16.Content.ReadAsStringAsync();
                                                                    var jsonData16 = JsonConvert.DeserializeObject<GetStatisticsDTO>(value16);
                                                                    ViewBag.blogTitleByMaxBlogComment = jsonData16.BlogTitleByMaxBlogComment;

                                                                }
                                                            }
                                                        }
                                                        }
                                                }

                                            }
                                           

                                        }
                                    }
                                }

                            }

                            }

                    }


                }
            }
            return View();
        }
    }
}
