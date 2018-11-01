using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtremeAspNetCoreApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeAspNetCoreApp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
