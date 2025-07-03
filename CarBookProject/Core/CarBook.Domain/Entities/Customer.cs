using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarBook.Domain.Entities
{
    [Table("Customers")]
    public class Customer
    {
        public int CustomerId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(30)]
        public string Mail { get; set; }
        public List<RentACarProcess> RentACarProcess { get; set; }
    }
}
