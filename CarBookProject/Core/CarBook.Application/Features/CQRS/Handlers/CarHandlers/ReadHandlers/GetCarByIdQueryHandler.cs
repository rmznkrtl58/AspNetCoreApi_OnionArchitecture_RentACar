using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.ReadHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery p)
        {
            var findCar = await _repository.GetValueByIdAsync(p.Id);
            return new GetCarByIdQueryResult()
            {
                BigImageUrl = findCar.BigImageUrl,
                BrandId = findCar.BrandId,
                CarId = findCar.CarId,
                CoverImageUrl = findCar.CoverImageUrl,
                FuelType = findCar.FuelType,
                Km  = findCar.Km,
                Luggage= findCar.Luggage,
                Model = findCar.Model,
                Seat = findCar.Seat,
                Transmission=findCar.Transmission
            };
        }
    }
}
