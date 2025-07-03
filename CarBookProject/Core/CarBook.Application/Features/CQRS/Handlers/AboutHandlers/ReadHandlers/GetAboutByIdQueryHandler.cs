using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.ReadHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;
        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var findAbout = await _repository.GetValueByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutId = findAbout.AboutId,
                Description = findAbout.Description,
                ImageUrl = findAbout.ImageUrl,
                Title = findAbout.Title
            };
        }
    }
}
