using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers.ReadHandlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserRepository;
		private readonly IRepository<AppRole> _appRoleRepository;
		public GetCheckAppUserQueryHandler(IRepository<AppUser> appUser, IRepository<AppRole> appRoler)
		{
			_appUserRepository = appUser;
			_appRoleRepository = appRoler;
		}
		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			//Kontrol Resultım Kullanıcı var mı yok mu?
			var values = new GetCheckAppUserQueryResult();
			//parametremden gelen değerle appUser tablomdaki 
			//Usename ve userPassword proplarım eşleşip userımı bulacağım
			var user = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.Username && x.UserPassword == request.Password);
			if (user == null)
			{
				//kullanıcım bulunmassa IsExist durumu yani kullanıcı eşleşmiyor
				values.IsExist = false;
			}
			else
			{
				values.IsExist = true;
				values.Username = user.UserName;
				values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
				values.Id = user.AppUserId;
			}
			return values;
		}
	}
}
