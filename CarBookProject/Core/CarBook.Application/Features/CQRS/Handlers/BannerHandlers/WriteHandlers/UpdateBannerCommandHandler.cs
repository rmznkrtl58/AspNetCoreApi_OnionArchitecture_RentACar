using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.WriteHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand c)
        {
            var findValue = await _repository.GetValueByIdAsync(c.BannerId);
            findValue.Description = c.Description;
            findValue.VideoDescription = c.VideoDescription;
            findValue.VideoUrl= c.VideoUrl;
            findValue.Title= c.Title;
            await _repository.UpdateAsync(findValue);
        }
    } 
}
