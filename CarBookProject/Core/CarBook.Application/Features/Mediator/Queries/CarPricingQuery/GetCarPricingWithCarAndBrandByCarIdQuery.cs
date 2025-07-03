using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQuery
{
    public class GetCarPricingWithCarAndBrandByCarIdQuery:IRequest<List<GetCarPricingWithCarAndBrandByCarIdQueryResult>>
    {
        public int CarId { get; set; }
    }
}
