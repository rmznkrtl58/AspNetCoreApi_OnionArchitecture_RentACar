using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Fiyatlandırma Bilgileri Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Fiyatlandırma Bilgisi Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand c)
        {
            await _mediator.Send(c);
            return Ok("Fiyatlandırma Bilgisi Kaydedildi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand c)
        {
            await _mediator.Send(c);
            return Ok("Fiyatlandırma Bilgisi Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            DeletePricingCommand c = new DeletePricingCommand(id);
            await _mediator.Send(c);
            return Ok("Fiyatlandırma Bilgisi Silindi!");
        }
    }
}
