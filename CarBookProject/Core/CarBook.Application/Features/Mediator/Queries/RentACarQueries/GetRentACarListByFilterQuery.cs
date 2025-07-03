using CarBook.Application.Features.Mediator.Results.RentACarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarListByFilterQuery : IRequest<List<GetRentACarListByFilterQueryResult>>
    {
        //parametrelerim
        //location Id'ye gelen değerle Available parametremde true'ya 
        //eşitse Bu parametrelere göre listeyi döndürcek
        public int LocationId { get; set; }
        public bool Available { get; set; }
    }
}
