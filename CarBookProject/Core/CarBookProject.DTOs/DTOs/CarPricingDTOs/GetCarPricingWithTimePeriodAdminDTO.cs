using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.CarPricingDTOs
{
    public class GetCarPricingWithTimePeriodAdminDTO
    {
        public string model { get; set; }
        public decimal dailyPrice { get; set; }
        public decimal weeklyPrice { get; set; }
        public decimal monthlyPrice { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
