using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
   public class GetCarPricingByIdQueryResult
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public Decimal Price { get; set; }
    }
}
