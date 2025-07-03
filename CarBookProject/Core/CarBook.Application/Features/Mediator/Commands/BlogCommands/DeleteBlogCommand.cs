using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
    public class DeleteBlogCommand:IRequest
    {
        public DeleteBlogCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
