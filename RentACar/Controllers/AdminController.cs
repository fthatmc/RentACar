using Microsoft.AspNetCore.Mvc;

namespace RentACar.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
