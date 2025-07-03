using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
   public class Feature
    {
        public int FeatureId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        //çoka-çok ilişki
        public List<CarFeature> CarFeatures { get; set; }
    }
}
