using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarListByFilter(int LocationId,bool AvailableStatus)
        {
            GetRentACarListByFilterQuery query = new GetRentACarListByFilterQuery()
            {
                Available=AvailableStatus,
                LocationId=LocationId
            };
            var values = await _mediator.Send(query);
            if (values != null)
            {
                return Ok(values);
            }
            return NotFound("Tetiklenen Değerler Bulunamadı!");
        }
    }
}
