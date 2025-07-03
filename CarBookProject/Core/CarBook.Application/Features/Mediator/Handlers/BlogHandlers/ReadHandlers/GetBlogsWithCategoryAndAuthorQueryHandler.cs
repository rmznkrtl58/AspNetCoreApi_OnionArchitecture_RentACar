using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.ReadHandlers
{
   public class GetBlogsWithCategoryAndAuthorQueryHandler:IRequestHandler<GetBlogsWithCategoryAndAuthorQuery,List<GetBlogsWithCategoryAndAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;
        public GetBlogsWithCategoryAndAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBlogsWithCategoryAndAuthorQueryResult>> Handle(GetBlogsWithCategoryAndAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogsWithCategoryAndAuthor();
            return values.Select(x => new GetBlogsWithCategoryAndAuthorQueryResult()
            {
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreateDate = x.CreateDate,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Title= x.Title,
                AuthorName=x.Author.NameSurname,
                CategoryName=x.Category.Name
            }).ToList();
        }
    }
}
