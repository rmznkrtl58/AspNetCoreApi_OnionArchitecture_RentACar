﻿using MediatR;


namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class CreateServiceCommand:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string İconUrl { get; set; }
    }
}
