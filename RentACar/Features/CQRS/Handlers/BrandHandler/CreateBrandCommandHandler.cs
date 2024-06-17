using RentACar.DAL.Context;
using RentACar.DAL.Entities;
using RentACar.Features.CQRS.Commands.BrandCommands;

namespace RentACar.Features.CQRS.Handlers.BrandHandler
{
    public class CreateBrandCommandHandler
    {
        private readonly Context _context;

        public CreateBrandCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateBrandCommand command)
        {
            _context.Brands.Add(new Brand
            {
                Name = command.Name
            });
            _context.SaveChanges();

        }
    }
}
