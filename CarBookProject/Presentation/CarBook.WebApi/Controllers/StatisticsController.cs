using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public StatisticsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpGet("BlogTitleByMaxBlogComment")]
        public async Task<IActionResult> BlogTitleByMaxBlogComment()
        {
            var value = await _mediatR.Send(new BlogTitleByMaxBlogCommentQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("BrandNameByMaxCar")]
        public async Task<IActionResult> BrandNameByMaxCar()
        {
            var value = await _mediatR.Send(new BrandNameByMaxCarQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await _mediatR.Send(new GetAuthorCountQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var value = await _mediatR.Send(new GetAvgRentPriceForDailyQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var value = await _mediatR.Send(new GetAvgRentPriceForMonthlyQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var value = await _mediatR.Send(new GetAvgRentPriceForWeeklyQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediatR.Send(new GetBlogCountQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _mediatR.Send(new GetBrandCountQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = await _mediatR.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = await _mediatR.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelDiesel")]
        public async Task<IActionResult> GetCarCountByFuelDiesel()
        {
            var value = await _mediatR.Send(new GetCarCountByFuelDieselQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var value = await _mediatR.Send(new GetCarCountByFuelElectricQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetCarCountByKmSmallerThen30000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen30000()
        {
            var value = await _mediatR.Send(new GetCarCountByKmSmallerThen30000Query());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetCarCountByTranmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTranmissionIsAuto()
        {
            var value = await _mediatR.Send(new GetCarCountByTranmissionIsAutoQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var value = await _mediatR.Send(new GetLocationCountQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);

        }
        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var value = await _mediatR.Send(new GetCarCountQuery());
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
    }
}
