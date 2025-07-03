using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistersController : ControllerBase
	{
		private readonly IMediator _mediator;
		public RegistersController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateAppUserCommand a)
		{
			await _mediator.Send(a);
			return Ok("Kullanıcı Başarıyla Oluşturuldu!");
		}
	}
}
