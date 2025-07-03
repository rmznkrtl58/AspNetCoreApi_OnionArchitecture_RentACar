using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers.WriteHandlers
{
    public class DeleteFooterCommandHandler : IRequestHandler<DeleteFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public DeleteFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteFooterCommand request, CancellationToken cancellationToken)
        {
            var findValue = await _repository.GetValueByIdAsync(request.Id);
            await _repository.DeleteAsync(findValue);
        }
    }
}
