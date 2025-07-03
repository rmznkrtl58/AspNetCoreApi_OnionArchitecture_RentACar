using System.ComponentModel.DataAnnotations;


namespace CarBook.Domain.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(250)]
        public string ImageUrl { get; set; }
    }
}
