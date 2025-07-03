using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers.WriteHandlers
{
    public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;
        public CreateCarFeatureCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }
        async Task IRequestHandler<CreateCarFeatureCommand>.Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.CreateCarFeature(new CarFeature()
            {
                Available = false,
                FeatureId= request.FeatureId,
                CarId= request.CarId,
            });   
        }
    }
}
