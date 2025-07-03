using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers.ReadHandlers
{   
    public class GetCarBrandAndModelByRentPriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMinQuery, GetCarBrandAndModelByRentPriceDailyMinQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarBrandAndModelByRentPriceDailyMinQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDailyMinQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetCarBrandAndModelByRentPriceDailyMin();
            return new GetCarBrandAndModelByRentPriceDailyMinQueryResult()
            {
                CarBrandAndModelByRentPriceDailyMin = value
            };
        }
    }
}
