using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public List<Blog> GetLast3BlogWithAuthors();
        public List<Blog> GetBlogsWithCategoryAndAuthor();
        public Blog GetBlogByIdWithAuthor(int id);
        public List<Blog> GetLast5BlogList();
    }
}
