using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Yazar Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Yazar Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand c)
        {
            await _mediator.Send(c);
            return Ok("Yazar Kaydedildi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand c)
        {
            await _mediator.Send(c);
            return Ok("Yazar Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            DeleteAuthorCommand c = new DeleteAuthorCommand(id);
            await _mediator.Send(c);
            return Ok("Yazar Silindi!");
        }
    }
}
