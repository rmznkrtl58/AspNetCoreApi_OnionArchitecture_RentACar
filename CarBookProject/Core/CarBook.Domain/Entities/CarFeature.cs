using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarFeature
    {
        //Olay 1.nolu arabada 2.nolu özellik var mı yok mu?
        //veya 3.nolu arabada 5.nolu özellik var mı yok mu?
        //gibi bir somut olay mevcut
        public int CarFeatureId { get; set; }
        //çoka-çok ilişki
        public int CarId { get; set; }
        public Car Car { get; set; }
        //çoka-çok ilişki
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        //özellik mevcutmu değilmi?
        public bool Available { get; set; }
    }
}
