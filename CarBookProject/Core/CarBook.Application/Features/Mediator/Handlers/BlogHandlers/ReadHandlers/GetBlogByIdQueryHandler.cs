using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.ReadHandlers
{
    public class GetBlogByIdQueryHandler:IRequestHandler<GetBlogByIdQuery,GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;
        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var findBlog = await _repository.GetValueByIdAsync(request.Id);
            return new GetBlogByIdQueryResult()
            {
                AuthorId=findBlog.AuthorId,
                BlogId=findBlog.BlogId,
                CategoryId=findBlog.CategoryId,
                CoverImageUrl=findBlog.CoverImageUrl,
                CreateDate=findBlog.CreateDate,
                Description=findBlog.Description,
                Title=findBlog.Title,
                ShortDescription=findBlog.ShortDescription
            };
        }
    }
}
