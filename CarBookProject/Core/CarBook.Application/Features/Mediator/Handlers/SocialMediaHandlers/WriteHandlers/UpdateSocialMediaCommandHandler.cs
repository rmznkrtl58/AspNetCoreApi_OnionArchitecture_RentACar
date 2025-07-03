using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.WriteHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;
        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var findSocialMedia = await _repository.GetValueByIdAsync(request.SocialMediaId);
            findSocialMedia.Url= request.Url;
            findSocialMedia.Name= request.Name;
            findSocialMedia.Icon = request.Icon;
            await _repository.UpdateAsync(findSocialMedia);
        }
    }
}
