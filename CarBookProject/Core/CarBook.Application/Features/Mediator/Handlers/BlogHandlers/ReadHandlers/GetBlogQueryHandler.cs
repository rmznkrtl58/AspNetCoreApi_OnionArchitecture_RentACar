using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.ReadHandlers
{
    public class GetBlogQueryHandler:IRequestHandler<GetBlogQuery,List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return values.Select(x => new GetBlogQueryResult()
            {
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreateDate = x.CreateDate,
                Description = x.Description,
                Title = x.Title,
                ShortDescription=x.ShortDescription
            }).ToList();
        }
    }
}
