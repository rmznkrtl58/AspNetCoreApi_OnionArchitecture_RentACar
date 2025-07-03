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
    public class BrandNameByMaxCarQueryHandler : IRequestHandler<BrandNameByMaxCarQuery, BrandNameByMaxCarQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public BrandNameByMaxCarQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<BrandNameByMaxCarQueryResult> Handle(BrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.BrandNameByMaxCar();
            return new BrandNameByMaxCarQueryResult()
            {
                BrandNameByMaxCar = value
            };
        }
    }
}
