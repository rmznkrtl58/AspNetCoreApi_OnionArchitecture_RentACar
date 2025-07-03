using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers.ReadHandlers
{
	public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
	{
		private readonly ICarDescriptionRepository _repository;
		public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
		{
			_repository = repository;
		}
		public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarDescriptionByCarId(request.Id);
			return new GetCarDescriptionByCarIdQueryResult()
			{
				CarId = values.CarId,
				Description = values.Description
			};
		}
	}
}
