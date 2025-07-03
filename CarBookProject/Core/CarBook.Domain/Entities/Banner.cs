using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Banner
    {
        public int BannerId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [StringLength(200)]
        public string VideoDescription { get; set; }
        [StringLength(250)]
        public string VideoUrl { get; set; }
    }
}
