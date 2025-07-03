using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.ReadHandlers
{
    public class GetLast4CarsWithBrandsQueryHandler
    {
        private readonly ICarRepository _repository;
        public GetLast4CarsWithBrandsQueryHandler(ICarRepository carRepository)
        {
            _repository = carRepository;
        }
        public  List<GetLast4CarsWithBrandsQueryResult> Handle()
        {
            var values =_repository.GetLast4CarListWithBrands();
           return values.Select(x => new GetLast4CarsWithBrandsQueryResult()
            {
                BigImageUrl = x.BigImageUrl,
                BrandName=x.Brand.Name,
                CarId=x.CarId,
                CoverImageUrl=x.CoverImageUrl,
                FuelType=x.FuelType,
                Km=x.Km,
                Luggage=x.Luggage,
                Model=x.Model,
                Seat=x.Seat,
                Transmission=x.Transmission
            }).ToList();
        }
    }
}
