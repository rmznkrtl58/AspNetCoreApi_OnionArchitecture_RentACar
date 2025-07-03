using System.ComponentModel.DataAnnotations;


namespace CarBook.Domain.Entities
{
   public class Comment
    {
        public int CommentId { get; set; }
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(700)]
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
