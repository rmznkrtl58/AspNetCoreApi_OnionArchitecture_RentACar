using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers.ReadHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public GetCarCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetCarCount();
            return new GetCarCountQueryResult()
            {
                CarCount = value,
            };
        }
    }
}
