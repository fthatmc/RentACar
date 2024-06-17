using MediatR;
using RentACar.Features.Mediator.Queries.RentACarQueries;
using RentACar.Features.Mediator.Results.RentACarResults;
using RentACar.Features.Repositories;
using X.PagedList;

namespace RentACar.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.PickUpLocationID == request.PickUpLocationID || x.DropOffLocationID == request.DropOffLocationID
            || x.PickUpDate == request.PickUpDate || x.DropOffDate==request.DropOffDate);
            var result = values.Select(y => new GetRentACarQueryResult
            {
                CarID = y.CarID,
                Brand = y.Car.Brand.Name,
                Model = y.Car.Model,
                CoverImageUrl = y.Car.CoverImageUrl,
                Km = y.Car.Km,
                Transmission = y.Car.Transmission,
                Passenger = y.Car.Passenger,
                Luggage = y.Car.Luggage,
                Door = y.Car.Door,
                Fuel = y.Car.Fuel,
                Price = y.Car.Price,
            }).ToList();
            return result;
        }
    }
}


