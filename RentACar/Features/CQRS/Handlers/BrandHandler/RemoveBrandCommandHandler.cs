using RentACar.DAL.Context;
using RentACar.Features.CQRS.Commands.BrandCommands;

namespace RentACar.Features.CQRS.Handlers.BrandHandler
{
    public class RemoveBrandCommandHandler
    {
        private readonly Context _context;

        public RemoveBrandCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveBrandCommand command)
        {
            var values = _context.Brands.Find(command.BrandId);
            _context.Brands.Remove(values);
            _context.SaveChanges();
        }
    }
}
