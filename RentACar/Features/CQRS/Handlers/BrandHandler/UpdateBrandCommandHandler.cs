using RentACar.DAL.Context;
using RentACar.Features.CQRS.Commands.BrandCommands;

namespace RentACar.Features.CQRS.Handlers.BrandHandler
{
    public class UpdateBrandCommandHandler
    {
        private readonly Context _context;
        public UpdateBrandCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateBrandCommand command)
        {
            var value = _context.Brands.Find(command.BrandID);
            value.Name = command.Name;
            _context.SaveChanges();
        }
    }
}
