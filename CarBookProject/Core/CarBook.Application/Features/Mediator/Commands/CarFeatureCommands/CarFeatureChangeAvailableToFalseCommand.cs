

using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CarFeatureChangeAvailableToFalseCommand:IRequest
    {
        public CarFeatureChangeAvailableToFalseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
