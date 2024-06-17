using RentACar.DAL.Context;
using RentACar.Features.CQRS.Queries.LocationQueries;
using RentACar.Features.CQRS.Results.LocationResults;

namespace RentACar.Features.CQRS.Handlers.LocationHandler
{
    public class GetLocationByIdQueryHandler
    {
        private readonly Context _context;
        public GetLocationByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public GetLocationByIdQueryResult Handle(GetLocationByIdQuery query)
        {
            var value = _context.Locations.Find(query.Id);
            return new GetLocationByIdQueryResult
            {
                LocationID = value.LocationID,
                Name = value.Name
            };
        }
    }
}
