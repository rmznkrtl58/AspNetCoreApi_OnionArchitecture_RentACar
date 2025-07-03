using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.WriteHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand c)
        {
            var findCar = await _repository.GetValueByIdAsync(c.CarId);
            findCar.BrandId = c.BrandId;
            findCar.Model=c.Model;
            findCar.CoverImageUrl=c.CoverImageUrl;
            findCar.Km=c.Km;
            findCar.Transmission = c.Transmission;
            findCar.Seat=c.Seat;
            findCar.Luggage=c.Luggage;
            findCar.FuelType=c.FuelType;
            findCar.BigImageUrl=c.BigImageUrl;
            await _repository.UpdateAsync(findCar);
        }
    }
}
