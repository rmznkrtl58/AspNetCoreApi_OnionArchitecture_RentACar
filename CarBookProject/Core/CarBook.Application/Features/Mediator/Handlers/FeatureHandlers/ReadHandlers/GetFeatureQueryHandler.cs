using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.ReadHandlers
{   //IRequestHandler->MediatR kullanımı için uyguladım 
    //Olay bir istek ve yanıt istiyor istek querylerimiz 
    //yanıt iste querylerimize cevap veren resultlarımız
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return values.Select(z => new GetFeatureQueryResult()
            {
                FeatureId = z.FeatureId,
                Name = z.Name
            }).ToList();
        }
    }
}
