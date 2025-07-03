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
    public class UpdateAuthorCommandHandler:IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var findAuthor = await _repository.GetValueByIdAsync(request.AuthorId);
            findAuthor.Description= request.Description;
            findAuthor.NameSurname= request.NameSurname;
            findAuthor.ImageUrl= request.ImageUrl;
            await _repository.UpdateAsync(findAuthor);
        }
    }
}
