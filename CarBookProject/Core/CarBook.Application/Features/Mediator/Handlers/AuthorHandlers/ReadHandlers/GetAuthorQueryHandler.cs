using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.ReadHandlers
{
    public class GetAuthorQueryHandler:IRequestHandler<GetAuthorQuery,List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;
        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return values.Select(x => new GetAuthorQueryResult()
            {
                AuthorId = x.AuthorId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                NameSurname = x.NameSurname
            }).ToList();
        }
    }
}
