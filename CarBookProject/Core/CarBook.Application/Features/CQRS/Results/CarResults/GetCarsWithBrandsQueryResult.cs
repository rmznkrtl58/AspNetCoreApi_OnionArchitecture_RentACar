using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults
{
    public class GetCarsWithBrandsQueryResult
    {
        public int CarId { get; set; }
        //public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }//şanzıman
        public byte Seat { get; set; }//koltuk sayısı
        public byte Luggage { get; set; }//bagaj sayısı
        public string FuelType { get; set; }//benzin türü
        public string BigImageUrl { get; set; }
    }
}
