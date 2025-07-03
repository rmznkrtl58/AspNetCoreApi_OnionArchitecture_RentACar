﻿using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.WriteHandlers
{
    public class DeleteContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public DeleteContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteContactCommand c)
        {
            var findContact = await _repository.GetValueByIdAsync(c.Id);
            await _repository.DeleteAsync(findContact);
        }
    }
}
