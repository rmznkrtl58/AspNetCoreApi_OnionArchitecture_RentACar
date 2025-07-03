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
    public class GetCarCountByFuelDieselQueryHandler : IRequestHandler<GetCarCountByFuelDieselQuery, GetCarCountByFuelDieselQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public GetCarCountByFuelDieselQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<GetCarCountByFuelDieselQueryResult> Handle(GetCarCountByFuelDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetCarCountByFuelDiesel();
            return new GetCarCountByFuelDieselQueryResult()
            {
                CarCountByFuelDiesel = value
            };
        }
    }
}
