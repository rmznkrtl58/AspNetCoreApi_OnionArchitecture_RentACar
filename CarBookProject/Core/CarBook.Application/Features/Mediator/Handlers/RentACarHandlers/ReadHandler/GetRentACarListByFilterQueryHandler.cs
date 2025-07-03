using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces.RentACarInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers.ReadHandler
{
    public class GetRentACarListByFilterQueryHandler : IRequestHandler<GetRentACarListByFilterQuery, List<GetRentACarListByFilterQueryResult>>
    {
        private readonly IRentACarRepository _repository;
        public GetRentACarListByFilterQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetRentACarListByFilterQueryResult>> Handle(GetRentACarListByFilterQuery request, CancellationToken cancellationToken)
        {
            var valuesByFilter =await _repository.GetCarsByFilterAsync(x => x.LocationId == request.LocationId && x.AvailableStatus == true);
            var results= valuesByFilter.Select(x => new GetRentACarListByFilterQueryResult()
            {
               CarId=x.CarId,
               CoverImageUrl=x.Car.CoverImageUrl,
               BrandName=x.Car.Brand.Name,
               Model=x.Car.Model,
            }).ToList();
            return results;
        }
    }
}
