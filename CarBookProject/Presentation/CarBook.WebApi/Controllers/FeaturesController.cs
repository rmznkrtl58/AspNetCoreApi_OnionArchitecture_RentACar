using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        //IMediator yapımla bir kule misali
        //bütün uçaklarımla iletişim haline geçebiliyorum
        private readonly IMediator _mediator;
        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Öne Çıkanların Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Öne Çıkan Bulunamadı!");
            }
        }
        [HttpPost]                              
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand c)
        {
            //ekleme silme güncellemelerde direk isteği
            //bağlı olduğu command sınıfındaki parametre ile
            //atıyoruz
            await _mediator.Send(c);
            return Ok("Öne Çıkan Başarıyla Eklendi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand c)
        {
            //ekleme silme güncellemelerde direk isteği
            //bağlı olduğu command sınıfındaki parametre ile
            //atıyoruz
            await _mediator.Send(c);
            return Ok("Öne Çıkan Başarıyla Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            //ekleme silme güncellemelerde direk isteği
            //bağlı olduğu command sınıfındaki parametre ile
            //atıyoruz
            DeleteFeatureCommand c = new DeleteFeatureCommand(id);
            await _mediator.Send(c);
            return Ok("Öne Çıkan Başarıyla Silindi!");
        }
    }
}
