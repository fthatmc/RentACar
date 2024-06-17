using MediatR;

namespace RentACar.Features.Mediator.Commands.CarCommand
{
    public class RemoveCarCommand : IRequest
    {
        public int CarId { get; set; }

        public RemoveCarCommand(int carId)
        {
            CarId = carId;
        }
    }
}
