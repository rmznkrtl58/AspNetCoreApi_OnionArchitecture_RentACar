using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.ReadHandlers
{
    public class GetCarWithBrandByCarIdQueryHandler
    {
        private readonly ICarRepository _Repository;
        public GetCarWithBrandByCarIdQueryHandler(ICarRepository repository)
        {
            _Repository = repository;
        }
        public GetCarWithBrandByCarIdQueryResult Handle(GetCarWithBrandByCarIdQuery query)
        {
            var value = _Repository.GetCarWithBrandByCarId(query.Id);
            return new GetCarWithBrandByCarIdQueryResult()
            {
                BigImageUrl=value.BigImageUrl,
                BrandId=value.BrandId,
                Seat=value.Seat,
                BrandName= value.Brand.Name,
                CarId=value.CarId,
                CoverImageUrl=value.CoverImageUrl,
                FuelType=value.FuelType,
                Km=value.Km,
                Luggage=value.Luggage,
                Model= value.Model,
                Transmission = value.Transmission
            };
        }
    }
}
