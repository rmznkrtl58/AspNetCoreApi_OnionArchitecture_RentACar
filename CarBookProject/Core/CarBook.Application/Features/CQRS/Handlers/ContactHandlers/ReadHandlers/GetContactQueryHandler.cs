using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.ReadHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetListAllAsync();
            return values.Select(x => new GetContactQueryResult()
            {
                Mail=x.Mail,
                ContactId=x.ContactId,
                Message=x.Message,
                NameSurname= x.NameSurname,
                SendDate=x.SendDate,
                Subject = x.Subject
            }).ToList();
        }
    }
}
