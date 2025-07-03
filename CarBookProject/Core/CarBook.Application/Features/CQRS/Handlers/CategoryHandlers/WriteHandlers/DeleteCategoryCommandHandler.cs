using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.WriteHandlers
{
    public class DeleteCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCategoryCommand c)
        {
            var findCategory = await _repository.GetValueByIdAsync(c.Id);
            await _repository.DeleteAsync(findCategory);
        }
    }
}
