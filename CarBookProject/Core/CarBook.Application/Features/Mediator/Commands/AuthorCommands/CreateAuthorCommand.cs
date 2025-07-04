﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands
{
   public class CreateAuthorCommand:IRequest
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
