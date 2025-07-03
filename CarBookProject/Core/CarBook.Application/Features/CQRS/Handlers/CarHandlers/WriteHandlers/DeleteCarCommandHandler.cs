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
    public class DeleteCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public DeleteCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCarCommand c)
        {
            var findCar = await _repository.GetValueByIdAsync(c.Id);
            await _repository.DeleteAsync(findCar);
        }
    }
}
