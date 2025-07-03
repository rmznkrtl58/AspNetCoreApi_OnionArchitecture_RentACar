using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        [StringLength(200)]
        public string İconUrl { get; set; }
    }
}
