using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.ReadHandlers
{
    public class GetBlogByIdWithAuthorQueryHandler : IRequestHandler<GetBlogByIdWithAuthorQuery, GetBlogByIdWithAuthorQueryResult>
    {
        private readonly IBlogRepository _blogRepository;
        public GetBlogByIdWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<GetBlogByIdWithAuthorQueryResult> Handle(GetBlogByIdWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var value = _blogRepository.GetBlogByIdWithAuthor(request.Id);
            return new GetBlogByIdWithAuthorQueryResult()
            {
                AuthorId=value.AuthorId,
                BlogId=value.BlogId,
                CategoryId=value.CategoryId,
                CoverImageUrl=value.CoverImageUrl,
                CreateDate=value.CreateDate,
                Description=value.Description,
                ShortDescription=value.ShortDescription,
                Title=value.Title,
                AuthorDescription=value.Author.Description,
                AuthorImage=value.Author.ImageUrl,
                AuthorName=value.Author.NameSurname
            };
        }
    }
}
