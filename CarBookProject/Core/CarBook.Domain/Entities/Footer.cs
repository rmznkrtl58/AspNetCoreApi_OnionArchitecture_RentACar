using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Footer
    {
        public int FooterId { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(30)]
        public string Mail { get; set; }
    }
}
