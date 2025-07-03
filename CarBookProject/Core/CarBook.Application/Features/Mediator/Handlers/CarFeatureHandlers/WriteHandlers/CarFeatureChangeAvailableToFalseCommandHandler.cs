using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers.WriteHandlers
{
    public class CarFeatureChangeAvailableToFalseCommandHandler : IRequestHandler<CarFeatureChangeAvailableToFalseCommand>
    {
        private readonly ICarFeatureRepository _repository;
        public CarFeatureChangeAvailableToFalseCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(CarFeatureChangeAvailableToFalseCommand request, CancellationToken cancellationToken)
        {
            _repository.CarFeatureChangeAvailableToFalse(request.Id);
        }
    }
}
