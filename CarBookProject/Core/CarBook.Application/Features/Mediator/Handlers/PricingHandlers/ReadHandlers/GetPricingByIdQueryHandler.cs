using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.ReadHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;
        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var findPricing = await _repository.GetValueByIdAsync(request.Id);
            return new GetPricingByIdQueryResult()
            {
                PricingId = findPricing.PricingId,
                Name = findPricing.Name
            };
        }
    }
}
