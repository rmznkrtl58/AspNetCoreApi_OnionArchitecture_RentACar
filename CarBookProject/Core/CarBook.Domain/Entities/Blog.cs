using System.ComponentModel.DataAnnotations;

namespace CarBook.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        //Kategori ilişkisi
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //Yazar ilişkisi
        public int AuthorId { get; set; }
        public Author Author{ get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(250)]
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        [StringLength(500)]
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

