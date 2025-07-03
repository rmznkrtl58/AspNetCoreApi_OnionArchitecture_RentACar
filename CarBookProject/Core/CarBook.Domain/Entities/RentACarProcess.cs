using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarBook.Domain.Entities
{
    [Table("RentACarProcesses")]
    public class RentACarProcess
    {
        public int RentACarProcessId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime PickUpDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DropOffDate { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan PickUpTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan DropOffTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        [StringLength(500)]
        public string PickUpDescription { get; set; }
        [StringLength(500)]
        public string DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
