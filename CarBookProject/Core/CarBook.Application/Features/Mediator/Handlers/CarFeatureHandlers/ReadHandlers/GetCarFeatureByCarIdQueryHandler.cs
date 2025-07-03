using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers.ReadHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetListCarFeatureByCarId(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult()
            {
                Available=x.Available,
                BrandModel=x.Car.Brand.Name+" "+x.Car.Model,
                CarFeatureId=x.CarFeatureId,
                FeatureId=x.CarFeatureId,
                FeatureName=x.Feature.Name,
                CarId=x.CarId
            }).ToList();
        }
    }
}
