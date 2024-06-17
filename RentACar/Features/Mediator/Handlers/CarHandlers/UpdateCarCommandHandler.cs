using MediatR;
using RentACar.DAL.Context;
using RentACar.Features.Mediator.Commands.CarCommand;

namespace RentACar.Features.Mediator.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly Context _context;

        public UpdateCarCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Cars.FindAsync(request.CarID);
            values.CarID = request.CarID;
            values.BrandID = request.BrandID;
            values.Transmission = request.Transmission;
            values.Price = request.Price;
            values.Luggage = request.Luggage;
            values.CoverImageUrl = request.CoverImageUrl;
            values.Door = request.Door;
            values.Km = request.Km;
            values.Passenger = request.Passenger;
            values.Fuel = request.Fuel;
            values.Model = request.Model;
            await _context.SaveChangesAsync();

        }
    }
}
