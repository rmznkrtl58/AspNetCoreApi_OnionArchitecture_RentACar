using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Referans Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Referans Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand c)
        {
            await _mediator.Send(c);
            return Ok("Referans Kaydedildi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand c)
        {
            await _mediator.Send(c);
            return Ok("Referans Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            DeleteTestimonialCommand c = new DeleteTestimonialCommand(id);
            await _mediator.Send(c);
            return Ok("Referans Silindi!");
        }
    }
}
