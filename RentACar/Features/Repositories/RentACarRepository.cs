using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Context;
using RentACar.DAL.Entities;
using System.Linq.Expressions;

namespace RentACar.Features.Repositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly Context _context;

        public RentACarRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<RentCar>> GetByFilterAsync(Expression<Func<RentCar, bool>> filter)
        {
            var values = await _context.RentACars.Where(filter).Include(a=>a.Location).
                ThenInclude(b=>b.PickUpCarLocation).Include(a => a.Location).ThenInclude(c=>c.DropOffCarLocation).
                Include(x=>x.Car).ThenInclude(y=>y.Brand).ToListAsync();
            return values;
        }
    }
}

