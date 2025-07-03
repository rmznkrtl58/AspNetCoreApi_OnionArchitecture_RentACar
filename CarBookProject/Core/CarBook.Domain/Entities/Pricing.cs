using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Pricing//ödeme türleri->haftalık,aylık vb.
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
        //Çoka-çok ilişki
        public List<CarPricing> CarPricings { get; set; }
    }
}
