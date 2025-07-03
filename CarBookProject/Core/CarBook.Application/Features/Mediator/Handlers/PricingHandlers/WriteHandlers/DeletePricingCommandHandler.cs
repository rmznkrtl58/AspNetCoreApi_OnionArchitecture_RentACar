using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.WriteHandlers
{
    public class DeletePricingCommandHandler : IRequestHandler<DeletePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;
        public DeletePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeletePricingCommand request, CancellationToken cancellationToken)
        {
            var findPricing = await _repository.GetValueByIdAsync(request.Id);
            await _repository.DeleteAsync(findPricing);
        }
    }
}
