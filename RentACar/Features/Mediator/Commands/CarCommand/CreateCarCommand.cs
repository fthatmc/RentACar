using MediatR;

namespace RentACar.Features.Mediator.Commands.CarCommand
{
    public class CreateCarCommand : IRequest
    {
       
        public int BrandID { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Passenger { get; set; }
        public byte Door { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public decimal Price { get; set; }
    }
}
