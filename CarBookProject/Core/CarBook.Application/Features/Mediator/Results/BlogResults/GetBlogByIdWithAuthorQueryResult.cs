

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogByIdWithAuthorQueryResult
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorDescription { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
