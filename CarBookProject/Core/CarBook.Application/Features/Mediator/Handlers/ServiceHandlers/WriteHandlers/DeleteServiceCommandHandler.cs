using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers.WriteHandlers
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IRepository<Service> _repository;
        public DeleteServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var findService=await _repository.GetValueByIdAsync(request.Id);
            await _repository.DeleteAsync(findService);
        }
    }
}
