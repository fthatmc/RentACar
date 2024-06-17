using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentACar.Features.CQRS.Commands.BrandCommands;
using RentACar.Features.CQRS.Commands.LocationCommands;
using RentACar.Features.CQRS.Handlers.BrandHandler;
using RentACar.Features.CQRS.Handlers.LocationHandler;
using RentACar.Features.CQRS.Queries.BrandQueries;
using RentACar.Features.CQRS.Queries.LocationQueries;
using System.Drawing.Printing;
using X.PagedList;

namespace RentACar.Controllers
{
    public class BrandController : Controller
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;

        public BrandController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
        }

        public IActionResult BrandList(int page = 1, int pageSize = 7)
        {
            var values = _getBrandQueryHandler.Handle().ToPagedList(page, pageSize);
            return View(values);
        }
        

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(CreateBrandCommand command)
        {
            _createBrandCommandHandler.Handle(command);
            return RedirectToAction("BrandList");
        }

        public IActionResult RemoveBrand(int id)
        {
            _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return RedirectToAction("BrandList");
        }

        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var value = _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateBrand(UpdateBrandCommand command)
        {
            _updateBrandCommandHandler.Handle(command);
            return RedirectToAction("BrandList");
        }
    }
}
