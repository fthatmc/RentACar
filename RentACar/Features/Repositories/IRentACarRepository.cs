using RentACar.DAL.Entities;
using System.Linq.Expressions;

namespace RentACar.Features.Repositories
{
    public interface IRentACarRepository
    {
        Task<List<RentCar>> GetByFilterAsync(Expression<Func<RentCar, bool>> filter);
    }
}
