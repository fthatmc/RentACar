using MediatR;
using RentACar.Features.Mediator.Results.CarResults;

namespace RentACar.Features.Mediator.Queries.CarQueries
{
    public class GetCarByIdQuery : IRequest<GetCarByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarByIdQuery(int id)
        {
            Id = id;
        }
    }
}
