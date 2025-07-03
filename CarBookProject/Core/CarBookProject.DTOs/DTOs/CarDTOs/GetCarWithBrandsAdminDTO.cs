using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.CarDTOs
{
    public class GetCarWithBrandsAdminDTO
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
