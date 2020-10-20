using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTripLog.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace MyTripLog.Controllers
{
    public class TripController : Controller
    {
        private TripContext context;
        private List<Trip> trips;
        public TripController(TripContext ctx)
        {
            context = ctx;
            trips = context.Trips.OrderBy(c => c.TripId).ToList();
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewBag.Action = "Add";
            ViewBag.Trips = context.Trips.OrderBy(g => g.Destination).ToList();
            return View("Add", new Trip());
        }

        [HttpPost]
        public IActionResult Add(Trip trip)
        {
            if (ModelState.IsValid)
            {
                if (trip.TripId == 0)
                    context.Trips.Add(trip);
                else
                    context.Trips.Update(trip);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (trip.TripId == 0);
                return View(trip);
            }
        }
    }
}









