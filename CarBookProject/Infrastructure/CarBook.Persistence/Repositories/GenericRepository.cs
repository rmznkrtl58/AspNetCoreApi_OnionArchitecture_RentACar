using CarBook.Application.Features.RepositoryPattern.IGenericRepositories;
using CarBook.Persistence.Context;
using System.Linq.Expressions;


namespace CarBook.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CarBookContext _context;
        public GenericRepository(CarBookContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            using (var ent=_context)
            {
                var findValue = ent.Set<T>().Find(id);
                ent.Set<T>().Remove(findValue);
                ent.SaveChanges();
            }
        }
        public List<T> GetListAll()
        {
            using (var ent = _context)
            {
                var values = ent.Set<T>().ToList();
                return values;
            }
        }

        public List<T> GetListByCondition(Expression<Func<T, bool>> filter)
        {
            using (var ent=_context)
            {
                var values = ent.Set<T>().Where(filter).ToList();
                return values;
            }
        }

        public T GetValueById(int id)
        {
            using (var ent = _context)
            {
                var value = ent.Set<T>().Find(id);
                return value;
            }
        }

        public void Insert(T t)
        {
            using (var ent = _context)
            {
                ent.Set<T>().Add(t);
                ent.SaveChanges();
            }
        }

        public void Update(T t)
        {
            using (var ent = _context)
            {
                ent.Set<T>().Update(t);
                ent.SaveChanges();
            }
        }
    }
}
