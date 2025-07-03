using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.WriteHandlers
{
    public class CreateCarPricingCommandHandler:IRequestHandler<CreateCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;
        public CreateCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarPricing()
            {
                CarId = request.CarId,
                CarPricingId = request.CarId,
                PricingId = request.PricingId,
                Price = request.Price
            });
        }
    }
}
