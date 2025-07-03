using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers.ReadHandlers
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _repository;
		public GetReviewByCarIdQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetReviewByCarId(request.Id);
			return values.Select(z => new GetReviewByCarIdQueryResult()
			{
				Comment= z.Comment,
				CustomerImg= z.CustomerImg,
				CustomerName= z.CustomerName,
				RaytingValue= z.RaytingValue,
				ReviewDate = z.ReviewDate
			}).ToList();
		}
	}
}
