using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;


namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
	public class CarDescriptionRepository : ICarDescriptionRepository
	{
		private readonly CarBookContext _context;
		public CarDescriptionRepository(CarBookContext context)
		{
			_context = context;
		}
		public CarDescription GetCarDescriptionByCarId(int id)
		{
			using (var ent=_context)
			{
				var values = ent.CarDescriptions.Where(x => x.CarId == id).FirstOrDefault();
				return values;
			}
		}
	}
}
