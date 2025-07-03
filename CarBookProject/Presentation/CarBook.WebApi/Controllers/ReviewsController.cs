using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;
		
		public ReviewsController(IMediator mediator )
		{
			_mediator = mediator;
			
		}
		[HttpGet]
		public async Task<IActionResult> GetReviewByCarId(int id)
		{
			var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
			if (values == null)
			{
				return NotFound("Araca Ait Yorum Bulunamadı!");
			}
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand c)
		{
			CreateReviewValidator validator=new CreateReviewValidator();
			var validationResult = validator.Validate(c);
			if (validationResult.IsValid)
			{
				await _mediator.Send(c);
				return Ok("Yorum Başarıyla Yapıldı!");
			}
			else
			{
				return BadRequest(validationResult.Errors);
			}
		}
	}
}
