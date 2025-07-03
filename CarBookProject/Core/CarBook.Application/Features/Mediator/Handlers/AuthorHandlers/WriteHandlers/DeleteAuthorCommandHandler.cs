using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.WriteHandlers
{
   public class DeleteAuthorCommandHandler:IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        public DeleteAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var findAuthor = await _repository.GetValueByIdAsync(request.Id);
            await _repository.DeleteAsync(findAuthor);
        }
    }
}
