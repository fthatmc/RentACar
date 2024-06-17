using RentACar.DAL.Entities;

namespace RentACar.Features.Mediator.Results.CarResults
{
    public class GetCarQueryResult
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string Brand { get; set; }
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
