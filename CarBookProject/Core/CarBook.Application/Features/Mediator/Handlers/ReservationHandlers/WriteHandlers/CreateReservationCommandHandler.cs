using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers.WriteHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;
        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation()
            {
                Age = request.Age,
                CarId = request.CarId,
                Description = request.Description,
                DriverLicenseYear = request.DriverLicenseYear,
                DropOffLocationId= request.DropOffLocationId,
                Mail= request.Mail,
                NameSurname= request.NameSurname,
                Phone= request.Phone,
                PickUpLocationId= request.PickUpLocationId,
            });
        }
    }
}
