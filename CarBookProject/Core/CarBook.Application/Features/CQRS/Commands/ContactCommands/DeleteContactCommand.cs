using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
    public class DeleteContactCommand
    {
        public DeleteContactCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
