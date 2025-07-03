using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;
        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }
        public void CarFeatureChangeAvailableToFalse(int id)
        {
            using (var ent=_context)
            {
                var findCarFeature = ent.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
                findCarFeature.Available = false;
                ent.CarFeatures.Update(findCarFeature);
                ent.SaveChanges();
            }
        }
        public void CarFeatureChangeAvailableToTrue(int id)
        {
            using (var ent = _context)
            {
                var findCarFeature = ent.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
                findCarFeature.Available = true;
                ent.CarFeatures.Update(findCarFeature);
                ent.SaveChanges();
            }
        }

        public void CreateCarFeature(CarFeature carFeature)
        {
            using (var ent=_context)
            {
                ent.CarFeatures.Add(carFeature);
                ent.SaveChanges();
            }
        }

        public List<CarFeature> GetListCarFeatureByCarId(int carId)
        {
            using (var ent=_context)
            {
                var values = ent.CarFeatures.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x=>x.Feature).Where(x => x.CarId == carId).ToList();
                return values;
            }
        }
    }
}
