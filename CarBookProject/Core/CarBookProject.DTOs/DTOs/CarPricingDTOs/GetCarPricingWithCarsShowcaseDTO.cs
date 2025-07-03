using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.CarPricingDTOs
{
    public class GetCarPricingWithCarsShowcaseDTO
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }//fiyat
        public string PriceName { get; set; }//günlük haftalık aylık
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public string Model { get; set; }
        public int PricingId { get; set; }
    }
}
