using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignInController : ControllerBase
	{
		private readonly IMediator _mediator;
		public SignInController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> Login(GetCheckAppUserQuery p)
		{
			var values = await _mediator.Send(p);
			if (values.IsExist)//kullanıcım var mı?
			{
				return Created("", JWTTokenGenerator.GenerateToken(values));
			}
			else
			{
				return BadRequest("Kullanıcı Adı Veya Şifre Hatalıdır!");
			}
		}
	}
}
