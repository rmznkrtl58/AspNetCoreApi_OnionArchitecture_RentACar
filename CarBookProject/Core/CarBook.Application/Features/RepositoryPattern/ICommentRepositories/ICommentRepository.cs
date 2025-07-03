using CarBook.Application.Features.RepositoryPattern.IGenericRepositories;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RepositoryPattern.ICommentRepositories
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        public List<Comment> GetCommentListByBlogId(int id);
    }
}
