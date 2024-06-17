using RentACar.DAL.Context;
using RentACar.Features.CQRS.Commands.LocationCommands;

namespace RentACar.Features.CQRS.Handlers.LocationHandler
{
    public class UpdateLocationCommandHandler
    {

        private readonly Context _context;
        public UpdateLocationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateLocationCommand command)
        {
            var value = _context.Locations.Find(command.LocationID);
            value.Name = command.Name;
            _context.SaveChanges();
        }
    }
}
