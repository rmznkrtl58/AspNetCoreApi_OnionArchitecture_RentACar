using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Hizmet Bilgileri Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Hizmet Bilgisi Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand c)
        {
            await _mediator.Send(c);
            return Ok("Hizmet Bilgisi Kaydedildi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand c)
        {
            await _mediator.Send(c);
            return Ok("Hizmet Bilgisi Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            DeleteServiceCommand c = new DeleteServiceCommand(id);
            await _mediator.Send(c);
            return Ok("Hizmet Bilgisi Silindi!");
        }
    }
}
