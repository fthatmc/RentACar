using MediatR;
using RentACar.Features.Mediator.Results.CarResults;
using RentACar.Features.Mediator.Results.RentACarResults;

namespace RentACar.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
    {
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public int? PickUpLocationID { get; set; }
        public int? DropOffLocationID { get; set; }
        public GetRentACarQuery(int PickLocationId, int DropLocationId, DateTime PickDate, DateTime DropDate)
        {
            PickUpDate = PickDate;
            DropOffDate = DropDate;
            PickUpLocationID = PickLocationId;
            DropOffLocationID = DropLocationId;
        }
    }
}
