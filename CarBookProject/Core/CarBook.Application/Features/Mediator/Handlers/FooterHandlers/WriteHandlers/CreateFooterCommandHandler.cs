using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers.WriteHandlers
{
    public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;
        public CreateFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateFooterCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Footer()
            {
                Address = request.Address,
                Description = request.Description,
                Mail = request.Mail,
                Phone = request.Phone
            });
        }
    }
}
