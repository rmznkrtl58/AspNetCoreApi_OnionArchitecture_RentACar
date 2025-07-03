using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern.ICommentRepositories;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.WriteHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            _commentRepository.Insert(new Comment()
            {
                BlogId = request.BlogId,
                CommentDate = request.CommentDate,
                NameSurname = request.NameSurname,
                Content = request.Content,
            });
        }
    }
}
