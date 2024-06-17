using RentACar.DAL.Context;
using RentACar.Features.CQRS.Results.BrandResults;

namespace RentACar.Features.CQRS.Handlers.BrandHandler
{
    public class GetBrandQueryHandler
    {
        private readonly Context _context;

        public GetBrandQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetBrandQueryResult> Handle()
        {
            var values = _context.Brands.Select(x => new GetBrandQueryResult
            {
                BrandID = x.BrandID,
                Name = x.Name,
            }).ToList();
            return values;
        }
    }
}
