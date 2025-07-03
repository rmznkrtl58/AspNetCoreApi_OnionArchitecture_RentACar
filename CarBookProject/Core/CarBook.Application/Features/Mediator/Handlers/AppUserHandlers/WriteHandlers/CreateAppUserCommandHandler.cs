using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers.WriteHandlers
{
	public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
	{
		private readonly IRepository<AppUser> _repository;

		public CreateAppUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new AppUser()
			{
				//Enum kullanımı
				AppRoleId = (int)RolesType.Member,
				UserName = request.Username,
				UserPassword = request.UserPassword,
			});
		}
	}
}
