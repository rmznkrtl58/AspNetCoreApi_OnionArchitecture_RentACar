using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.StatisticsDTOs
{
   public class GetStatisticsDTO
    {
        public string BlogTitleByMaxBlogComment { get; set; }
        public string BrandNameByMaxCar { get; set; }
        public int AuthorCount { get; set; }
        public double AvgRentPriceForDaily { get; set; }
        public double AvgRentPriceForMonthly { get; set; }
        public double AvgRentPriceForWeekly { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public string CarBrandAndModelByRentPriceDailyMin { get; set; }
        public string CarBrandAndModelByRentPriceDailyMax { get; set; }
        public int CarCountByFuelDiesel { get; set; }
        public int CarCountByFuelElectric { get; set; }
        public int CarCountByKmSmallerThen30000 { get; set; }
        public int CarCountByTranmissionIsAuto { get; set; }
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
    }
}
