using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.CarFeatureDTOs
{
    public class GetCarFeatureByCarIdAdminDTO
    {
        public int CarFeatureId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
        public string BrandModel { get; set; }
        public string FeatureName { get; set; }
        public int CarId { get; set; }
    }
}
