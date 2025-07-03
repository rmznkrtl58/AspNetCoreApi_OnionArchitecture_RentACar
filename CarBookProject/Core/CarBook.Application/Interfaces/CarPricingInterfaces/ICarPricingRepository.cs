using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;


namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
   public interface ICarPricingRepository
    {
        public List<CarPricing> GetCarPricingWithCars();
        public Task<List<CarPricing>> GetCarPricingWithCarAndBrandByCarId(int id);
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();
    }
}
