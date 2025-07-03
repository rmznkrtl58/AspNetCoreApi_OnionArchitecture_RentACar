using CarBook.Application.Features.RepositoryPattern.ICommentRepositories;
using CarBook.Application.Features.RepositoryPattern.IGenericRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : ICommentRepository
    {
        
        private readonly CarBookContext _context;
        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            using (var ent=_context)
            {
                var findValue=ent.Comments.Find(id);
                ent.Comments.Remove(findValue);
                ent.SaveChanges();
            }
        }

        public List<Comment> GetCommentListByBlogId(int id)
        {
            using (var ent=_context)
            {
                var values = ent.Comments.Where(x => x.BlogId == id);
                return values.ToList();
            }
        }

        public List<Comment> GetListAll()
        {
            using (var ent = _context)
            {
                var values = ent.Comments.Select(x => new Comment()
                {
                    BlogId = x.BlogId,
                    CommentDate = x.CommentDate,
                    CommentId = x.CommentId,
                    Content = x.Content,
                    NameSurname=x.NameSurname
                }).ToList();
                return values;
            }
        }

        public List<Comment> GetListByCondition(Expression<Func<Comment, bool>> filter)
        {
            using (var ent=_context)
            {
                var values = ent.Comments.Where(filter).ToList();
                return values;
            }
        }

        public Comment GetValueById(int id)
        {
            using (var ent = _context)
            {
                var value = ent.Comments.Find(id);
                return value;
            }
        }

        public void Insert(Comment t)
        {
            using (var ent = _context)
            {
                ent.Comments.Add(new Comment()
                {
                    CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    BlogId=t.BlogId,
                    NameSurname = t.NameSurname,
                    Content = t.Content,
                });
                ent.SaveChanges();
            }
        }

        public void Update(Comment t)
        {
            using (var ent = _context)
            {
                ent.Comments.Update(new Comment()
                {
                    BlogId=t.BlogId,
                    CommentDate=t.CommentDate,
                    Content = t.Content,
                    NameSurname=t.NameSurname,
                    CommentId=t.CommentId
                });
                ent.SaveChanges();
            }
        }
    }
}
