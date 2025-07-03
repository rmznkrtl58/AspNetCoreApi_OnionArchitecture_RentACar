using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.ReadHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult>Handle(GetContactByIdQuery p)
        {
            var values=await _repository.GetValueByIdAsync(p.Id);
            return new GetContactByIdQueryResult()
            {
                Subject = values.Subject,
                ContactId = values.ContactId,
                Mail = values.Mail,
                Message = values.Message,
                NameSurname = values.NameSurname,
                SendDate = values.SendDate
            };
        }
    }
}
