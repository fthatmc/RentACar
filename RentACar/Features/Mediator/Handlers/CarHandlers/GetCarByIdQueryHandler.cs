using MediatR;
using RentACar.DAL.Context;
using RentACar.DAL.Entities;
using RentACar.Features.Mediator.Queries.CarQueries;
using RentACar.Features.Mediator.Results.CarResults;

namespace RentACar.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly Context _context;

        public GetCarByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Cars.FindAsync(request.Id);
            return new GetCarByIdQueryResult
            {
                CarID = values.CarID,
                Brand = values.Brand.Name,
                BrandID = values.BrandID,
                CoverImageUrl = values.CoverImageUrl,
                Door = values.Door,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Passenger = values.Passenger,
                Price = values.Price,
                Transmission = values.Transmission
            };
        }
    }
}
