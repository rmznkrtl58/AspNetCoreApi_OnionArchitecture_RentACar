﻿using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
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
    public class CreateAuthorCommandHandler:IRequestHandler<CreateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        public CreateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Author()
            {
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                NameSurname=request.NameSurname
            });  
        }
    }
}
