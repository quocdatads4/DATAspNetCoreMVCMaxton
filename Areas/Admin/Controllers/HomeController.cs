﻿using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
