using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;
        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public  Blog GetBlogByIdWithAuthor(int id)
        {
            using (var ent=_context)
            {
                var value =ent.Blogs.Include(x => x.Author).Where(x => x.BlogId == id).FirstOrDefault();
                return value;
            }
        }

        public List<Blog> GetBlogsWithCategoryAndAuthor()
        {
            using (var ent = _context)
            {
                var blogList = ent.Blogs.Include(x => x.Author).Include(y => y.Category).ToList();
                return blogList;
            }
        }
        public List<Blog> GetLast3BlogWithAuthors()
        {
            using (var ent=_context)
            {
                var blogList = ent.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToList();
                return blogList;
            }
        }

        public List<Blog> GetLast5BlogList()
        {
            using (var ent=_context)
            {
                var values = ent.Blogs.Include(x => x.Category).Include(y=>y.Author).OrderByDescending(c => c.BlogId).Take(5).ToList();
                return values;
            }
        }
    }
}
