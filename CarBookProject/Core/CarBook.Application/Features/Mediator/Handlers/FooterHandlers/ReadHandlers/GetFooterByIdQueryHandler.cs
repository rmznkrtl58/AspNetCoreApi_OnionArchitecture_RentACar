using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers.ReadHandlers
{
    public class GetFooterByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResults>
    {
        private readonly IRepository<Footer> _footer;

        public GetFooterByIdQueryHandler(IRepository<Footer> footer)
        {
            _footer = footer;
        }

        public async Task<GetFooterByIdQueryResults> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
        {
            var findFooter = await _footer.GetValueByIdAsync(request.Id);
            return new GetFooterByIdQueryResults()
            {
                FooterId = findFooter.FooterId,
                Address = findFooter.Address,
                Description = findFooter.Description,
                Mail = findFooter.Mail,
                Phone = findFooter.Phone
            };
        }
    }
}
