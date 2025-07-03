using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.WriteHandlers
{
    public class DeleteBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public DeleteBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteBannerCommand c)
        {
            var findValue = await _repository.GetValueByIdAsync(c.Id);
            await _repository.DeleteAsync(findValue);
        }
    }
}
