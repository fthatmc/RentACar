using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.DAL.Context;
using RentACar.Features.Mediator.Commands.CarCommand;
using RentACar.Features.Mediator.Queries.CarQueries;

namespace RentACar.Controllers
{
    public class CarController : Controller
    {
        private readonly IMediator _mediator;
        private readonly Context _context;

        public CarController(IMediator mediator, Context context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> CarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            List<SelectListItem> values = (from x in _context.Brands.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.BrandID.ToString()
                                           }).ToList();
            ViewBag.brand = values;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            

            await _mediator.Send(command);
            return RedirectToAction("CarList");
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return RedirectToAction("CarList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            List<SelectListItem> values2 = (from x in _context.Brands.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.BrandID.ToString()
                                           }).ToList();
            ViewBag.brand = values2;
            var values = await _mediator.Send(new GetCarByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("CarList");
        }
    }
}
