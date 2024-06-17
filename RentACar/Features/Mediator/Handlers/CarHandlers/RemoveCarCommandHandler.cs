using MediatR;
using RentACar.DAL.Context;
using RentACar.Features.Mediator.Commands.CarCommand;

namespace RentACar.Features.Mediator.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand>
    {
        private readonly Context _context;

        public RemoveCarCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Cars.FindAsync(request.CarId);
            _context.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
