using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Lokasyon Bilgileri Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Lokasyon Bilgisi Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand c)
        {
            await _mediator.Send(c);
            return Ok("Lokasyon Bilgisi Kaydedildi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand c)
        {
            await _mediator.Send(c);
            return Ok("Lokasyon Bilgisi Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            DeleteLocationCommand c = new DeleteLocationCommand(id);
            await _mediator.Send(c);
            return Ok("Lokasyon Bilgisi Silindi!");
        }
    }
}
