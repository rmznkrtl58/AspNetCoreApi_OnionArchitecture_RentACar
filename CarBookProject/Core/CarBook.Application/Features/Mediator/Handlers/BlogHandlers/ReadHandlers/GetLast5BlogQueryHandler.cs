using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.ReadHandlers
{
    public class GetLast5BlogQueryHandler : IRequestHandler<GetLast5BlogQuery, List<GetLast5BlogListQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;
        public GetLast5BlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<List<GetLast5BlogListQueryResult>> Handle(GetLast5BlogQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetLast5BlogList();
            return values.Select(x => new GetLast5BlogListQueryResult()
            {
                AuthorName = x.Author.NameSurname,
                CategoryName = x.Category.Name,
                CreateDate = x.CreateDate,
                Title=x.Title
            }).ToList();
        }
    }
}
