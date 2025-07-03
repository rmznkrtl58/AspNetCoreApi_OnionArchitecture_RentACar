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
    internal class GetCarPricingWithCarQueryHandler:IRequestHandler<GetCarPricingWithCarsQuery,List<GetCarPricingWithCarsQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarsQueryResult()
            {
                BrandName=x.Car.Brand.Name,
                CarId=x.CarId,
                CarPricingId=x.CarPricingId,
                CoverImageUrl=x.Car.CoverImageUrl,
                Model=x.Car.Model,
                Price=x.Price,
                PriceName=x.Pricing.Name,
                PricingId=x.PricingId
            }).ToList();
        }
    }
}
