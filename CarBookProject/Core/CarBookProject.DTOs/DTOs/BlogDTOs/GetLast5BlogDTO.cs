using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.BlogDTOs
{
   public class GetLast5BlogDTO
    {
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
