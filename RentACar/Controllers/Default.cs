using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.DAL.Context;
using RentACar.Features.CQRS.Handlers.LocationHandler;
using RentACar.Features.Mediator.Queries.CarQueries;
using RentACar.Features.Mediator.Queries.RentACarQueries;
using RentACar.Models;

namespace RentACar.Controllers
{
    public class Default : Controller
    {
        private readonly IMediator _mediator;
        private readonly GetLocationQueryHandler _getLocationQueryHandler;

        public Default(IMediator mediator, GetLocationQueryHandler getLocationQueryHandler)
        {
            _mediator = mediator;
            _getLocationQueryHandler = getLocationQueryHandler;
        }

        public IActionResult Index()
        {
            ViewBag.pickuplocation = new SelectList(_getLocationQueryHandler.Handle(), "LocationID", "Name");
            ViewBag.dropdownlocation = new SelectList(_getLocationQueryHandler.Handle(), "LocationID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RentACar(SearchCarViewModel model)
        {
            var result = await _mediator.Send(new GetRentACarQuery(model.PickUpLocationID, model.DropDownLocationID, model.PickUpDate, model.DropDownDate));
            return View(result);
        }

        public async Task<IActionResult> CarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return View(values);
        }


    }
}
