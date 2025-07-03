using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.ServiceDTOs
{
    public class GetServiceAdminDTO
    {
        public int ServiceId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string İconUrl { get; set; }
    }
}
