using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.ReadHandlers
{
    public class GetSocialMediaByIdQueryHandler:IRequestHandler<GetSocialMediaByIdQuery,GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;
        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var findSocialMedia = await _repository.GetValueByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult()
            {
                Icon = findSocialMedia.Icon,
                Name = findSocialMedia.Name,
                SocialMediaId = findSocialMedia.SocialMediaId,
                Url = findSocialMedia.Url
            };
        }
    }
}
