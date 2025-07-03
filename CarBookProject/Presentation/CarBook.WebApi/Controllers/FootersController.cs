using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FootersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterList()
        {
            var values = await _mediator.Send(new GetFooterQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Sayfanın Alt Bilgisi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooter(int id)
        {
            var value = await _mediator.Send(new GetFooterByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Sayfanın Alt Bilgisi Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterCommand c)
        {
            //ekleme silme güncellemelerde direk isteği
            //bağlı olduğu command sınıfındaki parametre ile
            //atıyoruz
            await _mediator.Send(c);
            return Ok("Sayfanın Alt Bilgisi Başarıyla Eklendi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooter(UpdateFooterCommand c)
        {
            //ekleme silme güncellemelerde direk isteği
            //bağlı olduğu command sınıfındaki parametre ile
            //atıyoruz
            await _mediator.Send(c);
            return Ok("Sayfanın Alt Bilgisi Başarıyla Güncellendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFooter(DeleteFooterCommand c)
        {
            //ekleme silme güncellemelerde direk isteği
            //bağlı olduğu command sınıfındaki parametre ile
            //atıyoruz
            await _mediator.Send(c);
            return Ok("Sayfanın Alt Bilgisi Başarıyla Silindi!");
        }
    }
}
