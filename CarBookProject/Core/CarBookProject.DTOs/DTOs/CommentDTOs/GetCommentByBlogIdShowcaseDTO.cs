

namespace CarBookProject.DTOs.DTOs.CommentDTOs
{
    public class GetCommentByBlogIdShowcaseDTO
    {
        public int CommentId { get; set; }
        public string NameSurname { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogId { get; set; }
    }
}
