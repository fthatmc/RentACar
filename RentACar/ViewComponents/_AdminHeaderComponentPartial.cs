using Microsoft.AspNetCore.Mvc;

namespace RentACar.ViewComponents
{
    public class _AdminHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
