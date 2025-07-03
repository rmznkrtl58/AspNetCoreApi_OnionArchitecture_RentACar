using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.ReadHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery p)
        {
            var findBanner = await _repository.GetValueByIdAsync(p.Id);
            return new GetBannerByIdQueryResult()
            {
                BannerId = findBanner.BannerId,
                Description = findBanner.Description,
                Title = findBanner.Title,
                VideoDescription = findBanner.VideoDescription,
                VideoUrl= findBanner.VideoUrl
            };
        }
    }
}
