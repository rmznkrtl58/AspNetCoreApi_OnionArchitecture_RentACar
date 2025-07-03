using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _mediator.Send(new GetSocialMediaQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Sosyal Medya Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Sosyal Medya Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand c)
        {
            await _mediator.Send(c);
            return Ok("Sosyal Medya Kaydedildi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand c)
        {
            await _mediator.Send(c);
            return Ok("Sosyal Medya Güncellendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(DeleteSocialMediaCommand c)
        {
            await _mediator.Send(c);
            return Ok("Sosyal Medya Silindi!");
        }
    }
}
