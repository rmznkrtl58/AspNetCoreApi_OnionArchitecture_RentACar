using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.ReadHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values =await _repository.GetListAllAsync();
            return values.Select(x => new GetBannerQueryResult()
            {
                BannerId = x.BannerId,
                Description = x.Description,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl
            }).ToList();
        }
    }
}
