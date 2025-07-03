

namespace CarBookProject.DTOs.DTOs.CarDTOs
{
    public class CreateCarAdminDTO
    {
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }//şanzıman
        public byte Seat { get; set; }//koltuk sayısı
        public byte Luggage { get; set; }//bagaj sayısı
        public string FuelType { get; set; }//benzin türü
        public string BigImageUrl { get; set; }
    }
}
