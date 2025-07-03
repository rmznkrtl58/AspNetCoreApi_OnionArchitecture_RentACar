using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarPricing
    {
        //somutlaştırcak olursa 1 nolu arabanın "Clio" 1 nolu
        //ödeme türü "haftalık" 10000tl gibi
        //bir örnek daha olucaksa 3.nolu aracın "Fiat" 4 nolu
        //ödeme türü "Günlük" 2000 tl gibi çoka çok bir ilişki
        //mevcud
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Price { get; set; }
    }
}
