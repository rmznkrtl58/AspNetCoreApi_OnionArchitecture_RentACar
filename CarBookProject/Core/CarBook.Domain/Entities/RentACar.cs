using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACar
    {
        public int RentACarId { get; set; }
        public int LocationId { get; set; }//Arabanın Alındığı Konumun ID'si
        public Location Location { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public bool AvailableStatus { get; set; }
    }
}
