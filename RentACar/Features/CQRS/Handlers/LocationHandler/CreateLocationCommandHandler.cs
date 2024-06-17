using Microsoft.CodeAnalysis;
using RentACar.DAL.Context;
using RentACar.Features.CQRS.Commands.LocationCommands;
using System.Xml.Linq;
using Location = RentACar.DAL.Entities.Location;

namespace RentACar.Features.CQRS.Handlers.LocationHandler
{
    public class CreateLocationCommandHandler
    {
        private readonly Context _context;

        public CreateLocationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateLocationCommand command)
        {
            _context.Locations.Add(new Location
            {
                 Name = command.Name,
            });
            _context.SaveChanges();

        }
    }
}
