using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.WriteHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand c)
        {
            await _repository.CreateAsync(new Car()
            {
                BigImageUrl = c.BigImageUrl,
                BrandId= c.BrandId,
                Transmission=c.Transmission,
                Seat=c.Seat,
                Model=c.Model,
                Luggage=c.Luggage,
                Km=c.Km,
                FuelType=c.FuelType,
                CoverImageUrl=c.CoverImageUrl,
            });
        }
    }
}
