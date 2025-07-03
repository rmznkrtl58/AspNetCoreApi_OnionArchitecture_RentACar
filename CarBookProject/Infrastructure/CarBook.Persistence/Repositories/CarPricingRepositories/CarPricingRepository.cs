using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;
        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<List<CarPricing>> GetCarPricingWithCarAndBrandByCarId(int id)
        {
            using (var ent=_context)
            {
                var values =await ent.CarPricings.Where(x => x.CarId == id&&x.PricingId==1).Include(x => x.Car).ThenInclude(x => x.Brand).Include(x=>x.Pricing).ToListAsync();
                return values;
            }
        }
        public List<CarPricing> GetCarPricingWithCars()
        {
            using (var ent=_context)
            {
                //arabanın markası modeli,resmi,günlük haftalık aylık fiyatları,
                var values = ent.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(y => y.Pricing).ToList();
                return values;
            }
        }
        public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
        {
            //Adonet kullanımı
            List<CarPricingViewModel>values=new List<CarPricingViewModel>();
            using (var command=_context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,CoverImageUrl,PricingId,Price From CarPricings Inner Join Cars On Cars.CarId=CarPricings.CarId Inner Join Brands On Brands.BrandId=Cars.BrandId) As SourceTable Pivot (Sum(Price) For PricingID In ([1],[2],[3])) as PivotTable;";
                command.CommandType=System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var dbReader = command.ExecuteReader())
                {
                    while (dbReader.Read())//veritabanımı okuduğu müttetçe
                        //döngü devam etsin
                    {
                        CarPricingViewModel cpModel = new CarPricingViewModel()
                        {
                            Model = dbReader["Model"].ToString(),
                            //BrandName= dbReader["Name"].ToString(),
							CoverImageUrl = dbReader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>//view modelimdeki amounts değişkenim
                            //liste içeriği alabilir ama decimal türde liste içeriği alabilir
                            {
                                Convert.ToDecimal(dbReader[2]),
                                Convert.ToDecimal(dbReader[3]),
                                Convert.ToDecimal(dbReader[4])
                            }
                        };
                         values.Add(cpModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}
