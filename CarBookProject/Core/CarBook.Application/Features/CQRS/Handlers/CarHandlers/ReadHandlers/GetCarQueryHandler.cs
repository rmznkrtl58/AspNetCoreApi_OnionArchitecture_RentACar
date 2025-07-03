using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.ReadHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values=await _repository.GetListAllAsync();
            return values.Select(x => new GetCarQueryResult()
            {
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CarId = x.CarId,
                CoverImageUrl = x.CoverImageUrl,
                FuelType = x.FuelType,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat  = x.Seat,
                Transmission=x.Transmission
            }).ToList();
        }
    }
}
