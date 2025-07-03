using MediatR;


namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand:IRequest
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
