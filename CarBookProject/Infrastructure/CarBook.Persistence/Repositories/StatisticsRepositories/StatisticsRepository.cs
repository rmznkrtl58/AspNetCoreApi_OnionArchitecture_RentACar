using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;
        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }
        public string BlogTitleByMaxBlogComment()
        {
            using (var ent = _context)
            {
                var findBlogId = ent.Comments.GroupBy(x => x.BlogId).Select(x => new
                {
                    blogId = x.Key,
                    count = x.Count()
                }).OrderByDescending(x => x.count).Take(1).FirstOrDefault();
                string bTitle = ent.Blogs.Where(x => x.BlogId == findBlogId.blogId).Select(x => x.Title).FirstOrDefault();
                return bTitle;
            }
        }

        public string BrandNameByMaxCar()
        {
            using (var ent=_context)
            {
                //BrandId'ye göre gruplanma olmuştur ve seçim işleminde 
                //solda brandId sağda ise o brandId'ye göre kaç tane arabanın olduğu gösterimiştir.
                //sonra countu büyükten küçüğe doğru sıralayıp ilk değeri aldık çünkü en çok araba
                //olan değer ilk değer
                var findBrandId = ent.Cars.GroupBy(x => x.BrandId)
                .Select(x => new
                {
                    brandId = x.Key,
                    count = x.Count()
                }).OrderByDescending(x => x.count).Take(1).FirstOrDefault();
                string bName = ent.Brands.Where(x => x.BrandId == findBrandId.brandId).Select(x => x.Name).FirstOrDefault();
                return bName;
            }
        }
        //Yazar Sayısı
        public int GetAuthorCount()
        {
            using (var ent=_context)
            {
                var value = ent.Authors.Count();
                return value;
            }
        }
        //arabaların Günlük fiyatlarının ortalaması
        public double GetAvgRentPriceForDaily()
        {
            using (var ent = _context)
            {
                int pId = ent.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
                var value = ent.CarPricings.Where(x => x.PricingId == pId).Average(x => x.Price);
                return Convert.ToDouble(value);
            }
        }
        //arabaların Aylık fiyatlarının ortalaması
        public double GetAvgRentPriceForMonthly()
        {
            using (var ent = _context)
            {
                int pId = ent.Pricings.Where(x => x.Name == "Aylık").Select(x => x.PricingId).FirstOrDefault();
                var value = ent.CarPricings.Where(x => x.PricingId == pId).Average(x => x.Price);
                return Convert.ToDouble(value);
            }
        }
        //arabaların haftalık fiyatlarının ortalaması
        public double GetAvgRentPriceForWeekly()
        {
            using (var ent = _context)
            {
                int pId = ent.Pricings.Where(x => x.Name == "Haftalık").Select(x => x.PricingId).FirstOrDefault();
                var value = ent.CarPricings.Where(x => x.PricingId == pId).Average(x => x.Price);
                return Convert.ToDouble(value);
            }
        }
        //Blog Sayısı
        public int GetBlogCount()
        {
            using (var ent = _context)
            {
                var value = ent.Blogs.Count();
                return value;
            }
        }
        //Marka Sayısı
        public int GetBrandCount()
        {
            using (var ent = _context)
            {
                var value = ent.Brands.Count();
                return value;
            }
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {   //Günlük Fiyatı En Yüksek Olan Aracın marka ve modeli
            using (var ent=_context)
            {
                int pId = ent.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
                decimal maxPrice = ent.CarPricings.Where(x => x.PricingId == pId).Max(x => x.Price);
                int cId = ent.CarPricings.Where(x => x.Price == maxPrice).Select(x => x.CarId).FirstOrDefault();
                string carNameAndBrand = ent.Cars.Where(x => x.CarId == cId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
                return carNameAndBrand;
            }
        }
        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            //Günlük Fiyatı En düşük Olan Aracın marka ve modeli
            using (var ent = _context)
            {
                int pId = ent.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
                decimal minPrice = ent.CarPricings.Where(x => x.PricingId == pId).Min(x => x.Price);
                int cId = ent.CarPricings.Where(x => x.Price == minPrice).Select(x => x.CarId).FirstOrDefault();
                string carNameAndBrand = ent.Cars.Where(x => x.CarId == cId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
                return carNameAndBrand;
            }
        }
        //Elektirikli Arabaların Sayısı
        public int GetCarCountByFuelElectric()
        {
            using (var ent=_context)
            {
                var values = ent.Cars.Where(x => x.FuelType == "Elektirik").Count();
                return values;
            }
        }
        //Dizel Arabaların Sayısı
        public int GetCarCountByFuelDiesel()
        {
            using (var ent = _context)
            {
                var values = ent.Cars.Where(x => x.FuelType == "Dizel").Count();
                return values;
            }
        }
        //30000 km aşağısandıki arabaların listesi
        public int GetCarCountByKmSmallerThen30000()
        {
            using (var ent=_context)
            {
                var values = ent.Cars.Where(x => x.Km <= 30000).Count();
                return values;
            }
        }
        //Otomatik Fitesli arabaların sayısı
        public int GetCarCountByTranmissionIsAuto()
        {
            using (var ent=_context)
            {
                var value = ent.Cars.Where(x => x.Transmission == "Otomatik").Count();
                return value;
            }
        }
        //Konum Sayısı
        public int GetLocationCount()
        {
            using (var ent = _context)
            {
                var value = ent.Locations.Count();
                return value;
            }
        }

        public int GetCarCount()
        {
            using (var ent=_context)
            {
                var value = ent.Cars.Count();
                return value;
            }
        }
    }
}
