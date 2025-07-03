using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        //bire-çok ilişki bir araba bir markaya aittir
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        [StringLength(30)]
        public string Model { get; set; }
        [StringLength(300)]
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        [StringLength(30)]
        public string Transmission { get; set; }//şanzıman
        public byte Seat { get; set; }//koltuk sayısı
        public byte Luggage { get; set; }//bagaj sayısı
        [StringLength(30)]
        public string FuelType { get; set; }//benzin türü
        [StringLength(300)]
        public string BigImageUrl { get; set; }
        //çoka-çok ilişki
        public List<CarFeature> CarFeatures { get; set; }
        //Bire-Çok İlişki
        public List<CarDescription> CarDescriptions { get; set; }
        //çoka-çok ilişki
        public List<CarPricing> CarPricings { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcess> RentACarProcess { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
