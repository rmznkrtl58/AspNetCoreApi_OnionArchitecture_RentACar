using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.FeatureDTOs
{
    public class GetFeatureAdminDTO
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
    }
}
