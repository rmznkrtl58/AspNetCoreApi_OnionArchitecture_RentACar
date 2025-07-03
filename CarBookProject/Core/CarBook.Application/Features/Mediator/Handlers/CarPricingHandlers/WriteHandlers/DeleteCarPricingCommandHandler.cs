using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.WriteHandlers
{
    public class DeleteCarPricingCommandHandler : IRequestHandler<DeleteCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;
        public DeleteCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCarPricingCommand request, CancellationToken cancellationToken)
        {
            var findCarPricing = await _repository.GetValueByIdAsync(request.Id);
            await _repository.DeleteAsync(findCarPricing);
        }
    }
}
