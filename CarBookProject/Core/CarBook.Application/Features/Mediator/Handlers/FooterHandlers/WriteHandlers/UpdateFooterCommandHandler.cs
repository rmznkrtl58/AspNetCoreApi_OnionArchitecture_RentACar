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
    public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public UpdateFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
        {
            var findFooter = await _repository.GetValueByIdAsync(request.FooterId);
            findFooter.Description = request.Description;
            findFooter.Address = request.Address;
            findFooter.Phone = request.Phone;
            findFooter.Mail = request.Mail;
            await _repository.UpdateAsync(findFooter);
        }
    }
}
