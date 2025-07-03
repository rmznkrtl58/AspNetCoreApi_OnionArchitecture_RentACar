using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(30)]
        public string Mail { get; set; }
        [StringLength(30)]
        public string Subject { get; set; }
        [StringLength(500)]
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
