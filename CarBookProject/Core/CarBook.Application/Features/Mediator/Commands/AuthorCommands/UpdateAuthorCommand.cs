﻿using MediatR;


namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands
{
    public class UpdateAuthorCommand:IRequest
    {
        public int AuthorId { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
