using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers.WriteHandlers
{
    public class CarFeatureChangeAvailableToTrueCommandHandler : IRequestHandler<CarFeatureChangeAvailableToTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public CarFeatureChangeAvailableToTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CarFeatureChangeAvailableToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.CarFeatureChangeAvailableToTrue(request.Id);
        }
    }
}
