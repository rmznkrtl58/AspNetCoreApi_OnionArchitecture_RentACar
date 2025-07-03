using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.WriteHandlers
{
    public class UpdateCarPricingCommandHandler:IRequestHandler<UpdateCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;
        public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var findCarPricing = await _repository.GetValueByIdAsync(request.CarPricingId);
            findCarPricing.Price = request.Price;
            findCarPricing.PricingId = request.PricingId;
            findCarPricing.CarId = request.CarId;
            await _repository.UpdateAsync(findCarPricing);
        }
    }
}
