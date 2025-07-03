using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.RentACarResults
{
    public class GetRentACarListByFilterQueryResult
    {
        public int CarId { get; set; }
        public int LocationId { get; set; }
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }//fiyat
        public string PriceName { get; set; }//günlük haftalık aylık
    }
}
