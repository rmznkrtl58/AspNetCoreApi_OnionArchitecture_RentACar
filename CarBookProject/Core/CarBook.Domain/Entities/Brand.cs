using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Brand//Marka
    {
        public int BrandId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        //Bire-çok ilişki bir markada birden fazla araç olabilir.
        public List<Car> Cars { get; set; }

    }
}
