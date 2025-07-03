using MediatR;


namespace CarBook.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest
    {
         public string NameSurname { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public DateTime CommentDate{ get; set; }
    }
}
