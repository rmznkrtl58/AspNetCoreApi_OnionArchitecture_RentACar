using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarQueryHandler _listHandler;
        private readonly GetCarsWithBrandsQueryHandler _getCarListWithBrandHandler;
        private readonly GetLast4CarsWithBrandsQueryHandler _getLast4CarListWithBrandHandler;
        private readonly GetCarByIdQueryHandler _getHandler;
        private readonly CreateCarCommandHandler _createHandler;
        private readonly UpdateCarCommandHandler _updateHandler;
        private readonly DeleteCarCommandHandler _deleteHandler;
        private readonly GetCarWithBrandByCarIdQueryHandler _getCarWithBrandByCarIdQueryHandler;
        public CarsController(GetCarQueryHandler listHandler, GetCarByIdQueryHandler getHandler, CreateCarCommandHandler createHandler, UpdateCarCommandHandler updateHandler, DeleteCarCommandHandler deleteHandler, GetCarsWithBrandsQueryHandler getCarListWithBrandHandler, GetLast4CarsWithBrandsQueryHandler getLast4CarListWithBrandHandler, GetCarWithBrandByCarIdQueryHandler getCarWithBrandByCarIdQueryHandler)
        {
            _listHandler = listHandler;
            _getHandler = getHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getCarListWithBrandHandler = getCarListWithBrandHandler;
            _getLast4CarListWithBrandHandler = getLast4CarListWithBrandHandler;
            _getCarWithBrandByCarIdQueryHandler = getCarWithBrandByCarIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _listHandler.Handle();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Araba Listesi Bulunamadı!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getHandler.Handle(new GetCarByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Araba Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand c)
        {
            await _createHandler.Handle(c);
            return Ok("Araba Eklemesi Gerçekleşti!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand c)
        {
            await _updateHandler.Handle(c);
            return Ok("Araba Güncellemesi Gerçekleşti!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _deleteHandler.Handle(new DeleteCarCommand(id));
            return Ok("Araba Silindi!");
        }
        [HttpGet("GetCarListWithBrands")]
        public async Task<IActionResult> GetCarListWithBrands()
        {
            var values = _getCarListWithBrandHandler.Handle();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Marka ile Araba Listesi Bulunamadı!");
            }
        }
        [HttpGet("GetLast4CarsWithBrands")]
        public async Task<IActionResult> GetLast4CarsWithBrands()
        {
            var values = _getLast4CarListWithBrandHandler.Handle();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Marka ile Son 4 Araba Listesi Bulunamadı!");
            }
        }
        [HttpGet("GetCarWithBrandByCarId/{id}")]
        public async Task<IActionResult> GetLast4CarsWithBrands(int id)
        {
            var value = _getCarWithBrandByCarIdQueryHandler.Handle(new GetCarWithBrandByCarIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Marka ile Araba id'ye göre Bulunamadı!");
            }
        }
    }
}
