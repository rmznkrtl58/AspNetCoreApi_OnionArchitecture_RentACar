using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(250)]
        public string ImageUrl { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
