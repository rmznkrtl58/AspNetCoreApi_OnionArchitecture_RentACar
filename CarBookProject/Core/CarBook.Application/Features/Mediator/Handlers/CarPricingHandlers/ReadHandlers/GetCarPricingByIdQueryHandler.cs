using CarBook.Application.Features.Mediator.Queries.CarPricingQuery;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.ReadHandlers
{
    public class GetCarPricingByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, GetCarPricingByIdQueryResult>
    {
        private readonly IRepository<CarPricing> _repository;
        public GetCarPricingByIdQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarPricingByIdQueryResult> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var findCarPricing = await _repository.GetValueByIdAsync(request.Id);
            return new GetCarPricingByIdQueryResult()
            {
                CarId = findCarPricing.CarId,
                CarPricingId = findCarPricing.CarPricingId,
                Price = findCarPricing.Price,
                PricingId=findCarPricing.PricingId
            };
        }
    }
}
