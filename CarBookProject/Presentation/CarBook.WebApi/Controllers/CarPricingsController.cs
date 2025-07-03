using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Features.Mediator.Queries.CarPricingQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarPricingsWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarsQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Araba Fiyatlama Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarPricingById(int id)
        {
            var value = await _mediator.Send(new GetCarPricingByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Araba Fiyatlama Bilgisi Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand c)
        {
            await _mediator.Send(c);
            return Ok("Araba Fiyatlama Bilgisi Kaydedildi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingCommand c)
        {
            await _mediator.Send(c);
            return Ok("Araba Fiyatlama Bilgisi Güncellendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCarPricing(DeleteCarPricingCommand c)
        {
            await _mediator.Send(c);
            return Ok("Araba Fiyatlama Bilgisi Silindi!");
        }
        [HttpGet("GetCarPricingWithCarAndBrandByCarId/{id}")]
        public async Task<IActionResult> GetCarPricingWithCarAndBrandByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarPricingWithCarAndBrandByCarIdQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Araba Fiyatlama Listesi Bulunamadı!");
            }
        }
        [HttpGet("GetCarPricingWithTimePeriod")]
        public async Task<IActionResult> GetCarPricingWithTimePeriod()
        {
            var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Araba Fiyatlama Listesi Bulunamadı!");
            }
        }
    }
}
