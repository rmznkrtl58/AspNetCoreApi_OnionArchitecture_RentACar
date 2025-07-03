using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.ReadHandlers
{
    public class GetLast3BlogWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogWithAuthorsQuery, List<GetLast3BlogWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        public GetLast3BlogWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetLast3BlogWithAuthorsQueryResult>> Handle(GetLast3BlogWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogWithAuthors();
            return values.Select(x => new GetLast3BlogWithAuthorsQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName=x.Author.NameSurname,
                Title=x.Title,
                CoverImageUrl=x.CoverImageUrl,
                CreateDate = x.CreateDate,
                Description = x.Description,
                BlogId = x.BlogId,
                ShortDescription=x.ShortDescription,
            }).ToList();
        }
    }
}
