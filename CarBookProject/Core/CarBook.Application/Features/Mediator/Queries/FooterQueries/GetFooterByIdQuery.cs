using CarBook.Application.Features.Mediator.Results.FooterResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterQueries
{
   public class GetFooterByIdQuery:IRequest<GetFooterByIdQueryResults>
    {
        public GetFooterByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
