

namespace CarBookProject.DTOs.DTOs.ReservationDTOs
{
    public class CreateReservationShowcaseDTO
    {
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int CarId { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string Description { get; set; }
    }
}
