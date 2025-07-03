using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarBookContext _context;
        public Repository(CarBookContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T t)
        {
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T t)
        {
            _context.Set<T>().Remove(t);
            await _context.SaveChangesAsync();
        }

		public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
		{
           
                var value = await _context.Set<T>().SingleOrDefaultAsync(filter);
                return value;
           
		}

		public async Task<List<T>> GetListAllAsync()
        {
         return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetValueByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T t)
        {
            _context.Set<T>().Update(t);
            await _context.SaveChangesAsync();
        }
    }
}
