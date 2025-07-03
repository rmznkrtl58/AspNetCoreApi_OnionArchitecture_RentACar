using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.DTOs.DTOs.ReviewDTOs
{
	public class GetReviewByCarIdShowcaseDTO
	{
		public string CustomerName { get; set; }
		public string CustomerImg { get; set; }
		public string Comment { get; set; }
		public int RaytingValue { get; set; }
		public DateTime ReviewDate { get; set; }
	}
}
