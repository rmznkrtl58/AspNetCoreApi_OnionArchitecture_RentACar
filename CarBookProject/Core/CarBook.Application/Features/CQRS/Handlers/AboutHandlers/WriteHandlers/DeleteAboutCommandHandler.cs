using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.WriteHandlers
{
    public class DeleteAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public DeleteAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteAboutCommand c)
        {
            var findAbout =await _repository.GetValueByIdAsync(c.Id);
            await _repository.DeleteAsync(findAbout);
        }
    }
}
