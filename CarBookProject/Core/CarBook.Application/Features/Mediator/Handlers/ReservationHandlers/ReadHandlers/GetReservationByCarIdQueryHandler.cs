using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using CarBook.Application.Features.Mediator.Results.ReservationResults;
using CarBook.Application.Interfaces.ReservationInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers.ReadHandlers
{
    public class GetReservationByCarIdQueryHandler : IRequestHandler<GerReservationByCarIdQuery, GerReservationByCarIdQueryResult>
    {
        private readonly IReservationRepository _repository;

        public GetReservationByCarIdQueryHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<GerReservationByCarIdQueryResult> Handle(GerReservationByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetReservationByCarId(request.Id);
            return new GerReservationByCarIdQueryResult()
            {
                Name = values.Car.Model,
                BrandName = values.Car.Brand.Name,
                CoverImageUrl = values.Car.CoverImageUrl
            };
        }
    }
}
