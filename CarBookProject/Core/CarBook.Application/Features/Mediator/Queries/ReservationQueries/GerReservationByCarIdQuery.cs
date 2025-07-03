using CarBook.Application.Features.Mediator.Results.ReservationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GerReservationByCarIdQuery:IRequest<GerReservationByCarIdQueryResult>
    {
        public GerReservationByCarIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
