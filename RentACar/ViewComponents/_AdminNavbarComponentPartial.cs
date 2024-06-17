using Microsoft.AspNetCore.Mvc;

namespace RentACar.ViewComponents
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
