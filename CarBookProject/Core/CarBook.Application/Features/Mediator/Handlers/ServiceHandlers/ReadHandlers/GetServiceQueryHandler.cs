using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers.ReadHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;
        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return values.Select(x => new GetServiceQueryResult()
            {
                Description = x.Description,
                ServiceId = x.ServiceId,
                Title = x.Title,
                İconUrl = x.İconUrl
            }).ToList();
        }
    }
}
