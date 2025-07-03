using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
    public class DeleteAboutCommand
    {
        public DeleteAboutCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
