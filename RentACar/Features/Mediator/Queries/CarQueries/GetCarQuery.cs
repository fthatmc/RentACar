using MediatR;
using RentACar.Features.Mediator.Results.CarResults;

namespace RentACar.Features.Mediator.Queries.CarQueries
{
    public class GetCarQuery : IRequest<List<GetCarQueryResult>>
    {
    }
}
