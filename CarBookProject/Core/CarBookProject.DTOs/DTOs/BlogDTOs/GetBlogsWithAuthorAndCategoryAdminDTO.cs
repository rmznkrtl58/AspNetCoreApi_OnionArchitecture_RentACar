using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.BlogDTOs
{
   public class GetBlogsWithAuthorAndCategoryAdminDTO
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
