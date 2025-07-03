using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.FooterDTOs
{
    public class GetFooterShowcaseDTO
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
