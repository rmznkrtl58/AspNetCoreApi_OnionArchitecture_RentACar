﻿using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.WriteHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog()
            {
                AuthorId= request.AuthorId,
                CategoryId= request.CategoryId,
                CoverImageUrl= request.CoverImageUrl,
                Title = request.Title,
                Description = request.Description,
                CreateDate = request.CreateDate,
                ShortDescription = request.ShortDescription,
            });
        }
    }
}
