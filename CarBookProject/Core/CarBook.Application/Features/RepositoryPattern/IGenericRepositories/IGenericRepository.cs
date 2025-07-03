using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RepositoryPattern.IGenericRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetListAll();
        T GetValueById(int id);
        void Insert(T t);
        void Update(T t);
        void Delete(int id);
        List<T> GetListByCondition(Expression<Func<T, bool>> filter);
    }
}
