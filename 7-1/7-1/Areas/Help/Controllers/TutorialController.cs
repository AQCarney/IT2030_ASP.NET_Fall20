using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _7_1.Areas.Help.Controllers
{
    [Area("Help")]
    public class TutorialController : Controller
    {
        public IActionResult Index(string id)
        {
            if (id == "Page2")
            {
                return View("Page2");
            }
            else if (id == "Page3") {
                return View("Page3");
            }
            else
            {
                return View("Page1");
            }
        }
        public IActionResult Page1()
        {
            return View();
        }
        public IActionResult Page2()
        {
            
            return View();
        }
        public IActionResult Page3()
        {
            return View();
        }
    }
}
