using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandByIdQueryHandler _getHandler;
        private readonly GetBrandQueryHandler _listHandler;
        private readonly CreateBrandCommandHandler _createHandler;
        private readonly UpdateBrandCommandHandler _updateHandler;
        private readonly DeleteBrandCommandHandler _deleteHandler;

        public BrandsController(GetBrandByIdQueryHandler getHandler, GetBrandQueryHandler listHandler, CreateBrandCommandHandler createHandler, UpdateBrandCommandHandler updateHandler, DeleteBrandCommandHandler deleteHandler)
        {
            _getHandler = getHandler;
            _listHandler = listHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _listHandler.Handle();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Marka Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value =await _getHandler.Handle(new GetBrandByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Marka Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand c)
        {
            await _createHandler.Handle(c);
            return Ok("Marka Eklemesi Gerçekleşti!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand c)
        {
            await _updateHandler.Handle(c);
            return Ok("Marka Güncellemesi Gerçekleşti!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _deleteHandler.Handle(new DeleteBrandCommand(id));
            return Ok("Marka Silindi!");
        }
    }
}
