﻿using Microsoft.AspNetCore.Mvc;

namespace RentACar.ViewComponents
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
