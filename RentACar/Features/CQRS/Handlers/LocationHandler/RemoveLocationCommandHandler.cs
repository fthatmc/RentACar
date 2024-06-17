using RentACar.DAL.Context;
using RentACar.Features.CQRS.Commands.LocationCommands;

namespace RentACar.Features.CQRS.Handlers.LocationHandler
{
    public class RemoveLocationCommandHandler
    {
        private readonly Context _context;

        public RemoveLocationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveLocationCommand command)
        {
            var values = _context.Locations.Find(command.LocationId);
            _context.Locations.Remove(values);
            _context.SaveChanges();
        }
    }
}
