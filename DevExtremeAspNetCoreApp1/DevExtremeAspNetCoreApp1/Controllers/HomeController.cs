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
        public IActionResult Index([FromHeader(Name ="accept-Language")] string accept, [FromRoute(Name = "controller")] string t, [FromHeader] HeaderModel model)
        { 
            ViewBag.Text = accept;
            ModelState.AddModelError("Host", "Not Valid - validation from controller");
             return View(model);

        }

    }
}
