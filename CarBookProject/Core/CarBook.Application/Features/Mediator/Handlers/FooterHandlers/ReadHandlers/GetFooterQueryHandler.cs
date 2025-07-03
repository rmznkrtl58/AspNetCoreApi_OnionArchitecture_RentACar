using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers.ReadHandlers
{
    public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, List<GetFooterQueryResult>>
    {
        private readonly IRepository<Footer> _repository;

        public GetFooterQueryHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return values.Select(x => new GetFooterQueryResult()
            {
                Address = x.Address,
                Description = x.Description,
                FooterId = x.FooterId,
                Mail = x.Mail,
                Phone = x.Phone
            }).ToList();
        }
    }
}
