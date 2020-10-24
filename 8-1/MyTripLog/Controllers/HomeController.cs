using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTripLog.Models;
//using MyTripLog.Models;

namespace MyTripLog.Controllers
{
    public class HomeController : Controller
    {
        
        private TripContext context { get; set; }
        public HomeController(TripContext context)
        {
            this.context = context;
        }

        public ViewResult Index()
        {
            List<Trip> trips = context.Trips.OrderBy(t => t.StartDate).ToList();
            return View(trips);
        }



      
     
    }
}
