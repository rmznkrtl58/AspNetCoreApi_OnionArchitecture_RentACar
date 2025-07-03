using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly DeleteAboutCommandHandler _deleteAboutCommandHandler;

        public AboutsController(GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, DeleteAboutCommandHandler deleteAboutCommandHandler)
        {
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ListAbout()
        {
            var values = await _getAboutQueryHandler.Handle();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest("Listeye Ulaşılamadı");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var findAbout = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            if (findAbout != null)
            {
                return Ok(findAbout);
            }
            else
            {
                return NotFound("Hakkımda Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand c)
        {
            await _createAboutCommandHandler.Handle(c);
            return Ok("Hakkımda Yazısı Eklendi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand c)
        {
            await _updateAboutCommandHandler.Handle(c);
            return Ok("Hakkımda Yazısı Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _deleteAboutCommandHandler.Handle(new DeleteAboutCommand(id));
            return Ok("Hakkımda Başarıyla Silindi!");
        }
    }
}
