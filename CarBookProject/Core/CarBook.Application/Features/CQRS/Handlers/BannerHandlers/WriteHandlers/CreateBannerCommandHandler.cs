﻿using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.WriteHandlers
{
   public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBannerCommand c)
        {
          await _repository.CreateAsync(new Banner()
            {
                Description= c.Description,
                Title= c.Title,
                VideoDescription= c.VideoDescription,
                VideoUrl= c.VideoUrl
            });
        }
    }
}
