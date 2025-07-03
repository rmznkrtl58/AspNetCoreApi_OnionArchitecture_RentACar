

namespace CarBookProject.DTOs.DTOs.ReviewDTOs
{
	public class CreateReviewAdminDTO
	{
		public string CustomerName { get; set; }
		public string CustomerImg { get; set; }
		public string Comment { get; set; }
		public int RaytingValue { get; set; }
		public DateTime ReviewDate { get; set; }
		public int CarId { get; set; }
	}
}
