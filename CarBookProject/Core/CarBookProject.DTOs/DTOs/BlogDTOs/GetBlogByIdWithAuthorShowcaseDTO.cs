using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.BlogDTOs
{
    public class GetBlogByIdWithAuthorShowcaseDTO
    {
        public int BlogId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorDescription { get; set; }
    }
}
