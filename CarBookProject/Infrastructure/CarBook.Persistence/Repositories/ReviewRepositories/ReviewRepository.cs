using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.ReviewRepositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly CarBookContext _context;
		public ReviewRepository(CarBookContext context)
		{
			_context = context;
		}
		public List<Review> GetReviewByCarId(int id)
		{
			using (var ent=_context)
			{
				var values = ent.Reviews.Where(x => x.CarId == id).ToList();
				return values;
			}
		}
	}
}
