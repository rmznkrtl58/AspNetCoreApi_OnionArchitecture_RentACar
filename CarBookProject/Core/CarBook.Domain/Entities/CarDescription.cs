using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarDescription
    {
        public int CarDescriptionId { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
