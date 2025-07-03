using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.ReadHandlers
{
    public class GetCarsWithBrandsQueryHandler
    {
        private readonly ICarRepository _carRepository;
        public GetCarsWithBrandsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public List<GetCarsWithBrandsQueryResult> Handle()
        {
            var values = _carRepository.GetCarListWithBrands();
            return values.Select(x => new GetCarsWithBrandsQueryResult()
            {
                BigImageUrl = x.BigImageUrl,
                BrandName = x.Brand.Name,
                CarId = x.CarId,
                CoverImageUrl = x.CoverImageUrl,
                FuelType = x.FuelType,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
