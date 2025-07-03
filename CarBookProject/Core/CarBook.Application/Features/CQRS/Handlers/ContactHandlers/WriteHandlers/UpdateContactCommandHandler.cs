using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.WriteHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand c)
        {
            await _repository.UpdateAsync(new Contact()
            {
                ContactId = c.ContactId,
                Mail = c.Mail,
                Message = c.Message,
                NameSurname = c.NameSurname,
                SendDate = c.SendDate,
                Subject = c.Subject
            });
        }
    }
}
