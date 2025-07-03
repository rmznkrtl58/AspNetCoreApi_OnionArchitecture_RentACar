using CarBook.Application.Features.Mediator.Queries.CarPricingQuery;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.ReadHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithTimePeriod();
            return values.Select(x => new GetCarPricingWithTimePeriodQueryResult()
            {
                DailyPrice = x.Amounts[0],
                WeeklyPrice= x.Amounts[1],
                MonthlyPrice= x.Amounts[2],
                Model=x.Model,
                CoverImageUrl=x.CoverImageUrl
                //BrandName=x.BrandName
            }).ToList();
        }
    }
}
