using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.WriteHandlers
{
    public class DeleteBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public DeleteBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteBrandCommand c)
        {
            var findBrand = await _repository.GetValueByIdAsync(c.Id);
            await _repository.DeleteAsync(findBrand);
        }
    }
}
