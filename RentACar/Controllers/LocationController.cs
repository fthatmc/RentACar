using Microsoft.AspNetCore.Mvc;
using RentACar.Features.CQRS.Commands.LocationCommands;
using RentACar.Features.CQRS.Handlers.LocationHandler;
using RentACar.Features.CQRS.Queries.LocationQueries;
using X.PagedList;

namespace RentACar.Controllers
{
    public class LocationController : Controller
    {
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;
        private readonly UpdateLocationCommandHandler _updateLocationCommandHandler;
        private readonly RemoveLocationCommandHandler _removeLocationCommandHandler;
        private readonly GetLocationByIdQueryHandler _getLocationByIdQueryHandler;
        private readonly GetLocationQueryHandler _getLocationQueryHandler;

        public LocationController(CreateLocationCommandHandler createLocationCommandHandler, UpdateLocationCommandHandler updateLocationCommandHandler, RemoveLocationCommandHandler removeLocationCommandHandler, GetLocationByIdQueryHandler getLocationByIdQueryHandler, GetLocationQueryHandler getLocationQueryHandler)
        {
            _createLocationCommandHandler = createLocationCommandHandler;
            _updateLocationCommandHandler = updateLocationCommandHandler;
            _removeLocationCommandHandler = removeLocationCommandHandler;
            _getLocationByIdQueryHandler = getLocationByIdQueryHandler;
            _getLocationQueryHandler = getLocationQueryHandler;
        }

        public IActionResult LocationList(int page = 1, int pageSize = 7)
        {
            var values = _getLocationQueryHandler.Handle().ToPagedList(page, pageSize);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLocation(CreateLocationCommand command)
        {
            _createLocationCommandHandler.Handle(command);
            return RedirectToAction("LocationList");
        }

        public IActionResult RemoveLocation(int id)
        {
            _removeLocationCommandHandler.Handle(new RemoveLocationCommand(id));
            return RedirectToAction("LocationList");
        }

        [HttpGet]
        public IActionResult UpdateLocation(int id)
        {
            var value = _getLocationByIdQueryHandler.Handle(new GetLocationByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateLocation(UpdateLocationCommand command)
        {
            _updateLocationCommandHandler.Handle(command);
            return RedirectToAction("LocationList");
        }
    }
}
