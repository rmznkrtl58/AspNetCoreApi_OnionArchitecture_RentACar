using CarBook.Application.Features.Mediator.Queries.CarPricingQuery;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.ReadHandlers
{
    public class GetCarPricingWithCarAndBrandByCarIdQueryHandler : IRequestHandler<GetCarPricingWithCarAndBrandByCarIdQuery, List<GetCarPricingWithCarAndBrandByCarIdQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;
        public GetCarPricingWithCarAndBrandByCarIdQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }
        public async Task<List<GetCarPricingWithCarAndBrandByCarIdQueryResult>> Handle(GetCarPricingWithCarAndBrandByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values =await _carPricingRepository.GetCarPricingWithCarAndBrandByCarId(request.CarId);
            var carPricings = values.Select(x => new GetCarPricingWithCarAndBrandByCarIdQueryResult()
            {
                BrandName=x.Car.Brand.Name,
                CarId=x.Car.CarId,
                CarPricingId=x.CarPricingId,
                CoverImageUrl=x.Car.CoverImageUrl,
                Model=x.Car.Model,
                Price=x.Price,
                PriceName=x.Pricing.Name
            }).ToList();
            return carPricings.ToList();
        }
    }
}
