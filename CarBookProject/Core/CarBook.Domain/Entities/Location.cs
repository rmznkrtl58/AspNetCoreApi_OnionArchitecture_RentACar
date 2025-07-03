using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        [StringLength(50)]
        public string PointName { get; set; }
        public List<RentACar> RentACars { get; set; }
        //Çoka çoka ilişki mevcut alınacak ve bırakılacak noktalara ilişkide buluncaz
        public List<Reservation> PickUpReservation { get; set; }
        public List<Reservation> DropOffReservation { get; set; }
    }
}
