using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarFeatureByCarId")]
        public async Task<IActionResult> GetCarFeatureByCarId(int id)
        {
            var values= await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            if (values == null)
            {
                return NotFound(id+" 'li arabanın Özellikleri Bulunamadı ");
            }
            return Ok(values);
        }
        [HttpGet("ActiveCarFeature")]
        public async Task<IActionResult> ActiveCarFeature(int id)
        {
            _mediator.Send(new CarFeatureChangeAvailableToTrueCommand(id)); 
            return Ok("Araba Özelliği Aktif Edildi!");
        }
        [HttpGet("PassiveCarFeature")]
        public async Task<IActionResult> PassiveCarFeature(int id)
        {
            _mediator.Send(new CarFeatureChangeAvailableToFalseCommand(id));
            return Ok("Araba Özelliği Pasif Edildi!");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureCommand c)
        {
           await _mediator.Send(c);
           return Ok("İlgili Arabaya Özellik Eklendi!");
        }
    }
}
