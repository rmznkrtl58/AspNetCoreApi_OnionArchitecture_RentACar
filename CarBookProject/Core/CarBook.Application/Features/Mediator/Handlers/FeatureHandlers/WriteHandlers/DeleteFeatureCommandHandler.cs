﻿using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.WriteHandlers
{
    public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public DeleteFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
        {
            var findFeature = await _repository.GetValueByIdAsync(request.Id);
            await _repository.DeleteAsync(findFeature);
        }
    }
}
