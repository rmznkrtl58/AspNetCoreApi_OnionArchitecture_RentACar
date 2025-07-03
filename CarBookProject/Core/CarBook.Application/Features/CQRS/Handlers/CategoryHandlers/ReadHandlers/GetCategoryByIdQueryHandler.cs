using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.ReadHandlers
{
   public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;
        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery p)
        {
            var value = await _repository.GetValueByIdAsync(p.Id);
            return new GetCategoryByIdQueryResult()
            {
                Name=value.Name,
                CategoryId=value.CategoryId
            };
        }
    }
}
