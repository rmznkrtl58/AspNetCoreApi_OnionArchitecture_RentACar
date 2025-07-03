using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers.WriteHandlers
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;
        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var findLocation = await _repository.GetValueByIdAsync(request.LocationId);
            findLocation.PointName = request.PointName;
            await _repository.UpdateAsync(findLocation);
        }
    }
}
