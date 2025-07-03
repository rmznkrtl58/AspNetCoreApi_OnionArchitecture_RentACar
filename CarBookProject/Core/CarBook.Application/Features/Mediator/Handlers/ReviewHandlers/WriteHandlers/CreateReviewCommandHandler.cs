using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers.WriteHandlers
{
	public class CreateReviewCommandHandler:IRequestHandler<CreateReviewCommand>
	{
		private readonly IRepository<Review> _repository;
		public CreateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
		   await _repository.CreateAsync(new Review()
			{
				CarId = request.CarId,
				Comment= request.Comment,
				CustomerImg=request.CustomerImg,
				ReviewDate=Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				CustomerName=request.CustomerName,
				RaytingValue=request.RaytingValue,
			});
		}
	}
}
