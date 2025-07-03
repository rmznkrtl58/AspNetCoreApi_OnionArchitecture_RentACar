using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerQueryHandler _getListHandle;
        private readonly GetBannerByIdQueryHandler _getByIdHandler;
        private readonly CreateBannerCommandHandler _createHandler;
        private readonly UpdateBannerCommandHandler _updateHandler;
        private readonly DeleteBannerCommandHandler _deleteHandler;

        public BannersController(GetBannerQueryHandler getListHandle, GetBannerByIdQueryHandler getByIdHandler, CreateBannerCommandHandler createHandler, UpdateBannerCommandHandler updateHandler, DeleteBannerCommandHandler deleteHandler)
        {
            _getListHandle = getListHandle;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getListHandle.Handle();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Banner Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getByIdHandler.Handle(new GetBannerByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Banner Bilgisi Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand c)
        {
            await _createHandler.Handle(c);
            return Ok("Banner Bilgisi Eklendi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand c)
        {
            await _updateHandler.Handle(c);
            return Ok("Banner Bilgisi Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _deleteHandler.Handle(new DeleteBannerCommand(id));
            return Ok("Banner Bilgisi Silindi!");
        }
    }
}
