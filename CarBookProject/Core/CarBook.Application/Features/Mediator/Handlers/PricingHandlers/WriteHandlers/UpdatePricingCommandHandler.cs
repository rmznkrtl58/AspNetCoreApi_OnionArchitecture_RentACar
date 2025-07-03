using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.WriteHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;
        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var findPricing = await _repository.GetValueByIdAsync(request.PricingId);
            findPricing.Name= request.Name;
            await _repository.UpdateAsync(findPricing);
        }
    }
}
