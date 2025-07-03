using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAllAsync();
        Task<T> GetValueByIdAsync(int id);
        Task CreateAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<T> GetByFilterAsync(Expression<Func<T,bool>>filter); 
    }
}
