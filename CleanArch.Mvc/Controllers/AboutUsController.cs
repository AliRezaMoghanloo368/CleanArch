﻿using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
