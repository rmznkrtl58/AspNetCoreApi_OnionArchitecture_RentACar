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
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand c)
        {
            var findAbout =await _repository.GetValueByIdAsync(c.AboutId);
            findAbout.Title= c.Title;
            findAbout.Description= c.Description;
            findAbout.ImageUrl= c.ImageUrl;
            await _repository.UpdateAsync(findAbout);
        }
    }
}
