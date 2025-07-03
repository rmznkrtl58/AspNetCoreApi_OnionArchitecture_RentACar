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
    public class GetAvgRentPriceForMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
    {
        private readonly IStatisticsRepository _statisticRepository;
        public GetAvgRentPriceForMonthlyQueryHandler(IStatisticsRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetAvgRentPriceForMonthly();
            return new GetAvgRentPriceForMonthlyQueryResult()
            {
                AvgRentPriceForMonthly = value
            };
        }
    }
}
