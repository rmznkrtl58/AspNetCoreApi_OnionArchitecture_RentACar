using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
   public class Reservation
    {
        public int ReservationId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(30)]
        public string Mail { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int? PickUpLocationId { get; set; }
        public Location PickUpLocation { get; set; }
        public int? DropOffLocationId { get; set; }
        public Location DropOffLocation { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string? Description { get; set; }
    }
}
