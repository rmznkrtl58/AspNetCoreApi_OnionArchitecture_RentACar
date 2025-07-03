using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
