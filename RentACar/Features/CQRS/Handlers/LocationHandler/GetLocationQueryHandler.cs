using RentACar.DAL.Context;
using RentACar.Features.CQRS.Results.LocationResults;

namespace RentACar.Features.CQRS.Handlers.LocationHandler
{
    public class GetLocationQueryHandler
    {
        private readonly Context _context;

        public GetLocationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetLocationQueryResult> Handle()
        {
            var values = _context.Locations.Select(x => new GetLocationQueryResult
            {
                LocationID = x.LocationID,
                Name = x.Name,
            }).ToList();
            return values;
        }
    }
}
