using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTripLog.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MyTripLog.Controllers
{
    public class TripController : Controller
    {
        [Route("[controller]/{id?}")]
        public IActionResult Add(string id)
            {            
                if (id == "Page2")
                {
                    return View("Page2");
                }
                else if (id == "Page3")
                {
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







