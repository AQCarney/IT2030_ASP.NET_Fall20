using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _7_1.Areas.Help.Controllers
{
    [Area("Help")]
    public class HomeController : Controller
    {
        [Route("[controller]/{id?}")]
        public IActionResult Index()
        {
            return RedirectToAction("Page1", "Tutorial");
        }
    }
}
