using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Url { get; set; }
        [StringLength(50)]
        public string Icon { get; set; }
    }
}
