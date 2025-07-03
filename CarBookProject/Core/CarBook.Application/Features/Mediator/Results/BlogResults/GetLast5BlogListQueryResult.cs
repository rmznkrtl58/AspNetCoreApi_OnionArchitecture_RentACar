
namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetLast5BlogListQueryResult
    {
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
