using MediatR;
using RentACar.DAL.Context;
using RentACar.DAL.Entities;
using RentACar.Features.Mediator.Commands.CarCommand;

namespace RentACar.Features.Mediator.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly Context _context;

        public CreateCarCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _context.Cars.AddAsync(new Car
            {
               BrandID = request.BrandID,
               Model = request.Model,
               CoverImageUrl = request.CoverImageUrl,
               Door = request.Door,
               Fuel = request.Fuel,
               Km = request.Km,
               Luggage = request.Luggage,
               Passenger = request.Passenger,
               Price = request.Price,
               Transmission = request.Transmission,


                

            });
            await _context.SaveChangesAsync();
        }
    }
}
