using MediatR;



namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CarFeatureChangeAvailableToTrueCommand:IRequest
    {
        public CarFeatureChangeAvailableToTrueCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
