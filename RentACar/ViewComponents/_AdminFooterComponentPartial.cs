using Microsoft.AspNetCore.Mvc;

namespace RentACar.ViewComponents
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
