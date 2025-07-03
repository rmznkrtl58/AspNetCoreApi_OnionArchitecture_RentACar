using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.WriteHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var findBlog = await _repository.GetValueByIdAsync(request.BlogId);
            findBlog.Title = request.Title;
            findBlog.Description = request.Description;
            findBlog.CreateDate = request.CreateDate;
            findBlog.CategoryId = request.CategoryId;
            findBlog.AuthorId = request.AuthorId;
            findBlog.CoverImageUrl = request.CoverImageUrl;
            await _repository.UpdateAsync(findBlog);
        }
    }
}
