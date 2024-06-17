using RentACar.DAL.Context;
using RentACar.Features.CQRS.Queries.BrandQueries;
using RentACar.Features.CQRS.Results.BrandResults;

namespace RentACar.Features.CQRS.Handlers.BrandHandler
{
    public class GetBrandByIdQueryHandler
    {
        private readonly Context _context;
        public GetBrandByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public GetBrandByIdQueryResult Handle(GetBrandByIdQuery query)
        {
            var value = _context.Brands.Find(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandID = value.BrandID,
                Name = value.Name
            };
        }
    }
}
