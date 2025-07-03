

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        double GetAvgRentPriceForDaily();
        double GetAvgRentPriceForWeekly();
        double GetAvgRentPriceForMonthly();
        int GetCarCountByTranmissionIsAuto();
        string BrandNameByMaxCar();
        string BlogTitleByMaxBlogComment();
        int GetCarCountByKmSmallerThen30000();
        int GetCarCountByFuelDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();
    }
}
