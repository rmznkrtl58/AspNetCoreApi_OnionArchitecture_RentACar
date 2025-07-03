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
    public class GetCarCountByKmSmallerThen30000QueryHandler : IRequestHandler<GetCarCountByKmSmallerThen30000Query, GetCarCountByKmSmallerThen30000QueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public GetCarCountByKmSmallerThen30000QueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<GetCarCountByKmSmallerThen30000QueryResult> Handle(GetCarCountByKmSmallerThen30000Query request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetCarCountByKmSmallerThen30000();
            return new GetCarCountByKmSmallerThen30000QueryResult()
            {
                CarCountByKmSmallerThen30000 = value
            };
        }
    }
}
