using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers.ReadHandlers
{
    public class GetCarBrandAndModelByRentPriceDailyMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMaxQuery, GetCarBrandAndModelByRentPriceDailyMaxQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public GetCarBrandAndModelByRentPriceDailyMaxQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<GetCarBrandAndModelByRentPriceDailyMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetCarBrandAndModelByRentPriceDailyMax();
            return new GetCarBrandAndModelByRentPriceDailyMaxQueryResult()
            {
                CarBrandAndModelByRentPriceDailyMax = value
            };
        }
    }
}
