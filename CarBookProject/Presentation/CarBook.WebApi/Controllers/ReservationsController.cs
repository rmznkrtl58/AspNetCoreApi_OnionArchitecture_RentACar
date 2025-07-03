using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationsController(IMediator mediator) { _mediator = mediator; }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand c)
        {
            await _mediator.Send(c);
            return Ok("Rezervasyon Başarıyla Gerçekleşti!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationByCarId(int id)
        {
            var value = await _mediator.Send(new GerReservationByCarIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
    }
}
