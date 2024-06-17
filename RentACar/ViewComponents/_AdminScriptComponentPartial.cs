using Microsoft.AspNetCore.Mvc;

namespace RentACar.ViewComponents
{
    public class _AdminScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
