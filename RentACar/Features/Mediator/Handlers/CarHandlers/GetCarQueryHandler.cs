using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Context;
using RentACar.DAL.Entities;
using RentACar.Features.Mediator.Queries.CarQueries;
using RentACar.Features.Mediator.Results.CarResults;

namespace RentACar.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
    {
        private readonly Context _context;

        public GetCarQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cars.Select(x => new GetCarQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                Brand = x.Brand.Name,
                CoverImageUrl = x.CoverImageUrl,
                Door = x.Door,
                Fuel = x.Fuel,
                Luggage = x.Luggage,
                Model = x.Model,
                Passenger = x.Passenger,
                Price = x.Price,
                Transmission = x.Transmission,
                Km = x.Km

            }).ToListAsync();
        }
    }
}
