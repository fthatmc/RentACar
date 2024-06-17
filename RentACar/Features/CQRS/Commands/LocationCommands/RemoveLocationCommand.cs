namespace RentACar.Features.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand
    {
        public int LocationId { get; set; }

        public RemoveLocationCommand(int locationId)
        {
            LocationId = locationId;
        }
    }
}
