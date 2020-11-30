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
        private UnitOfWork data { get; set; }
        public TripController(TripContext context) => data = new UnitOfWork(context);

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ViewResult Add(string id = "")
        {
            TripViewModel vm = new TripViewModel();
            switch (id.ToLower())
            {
                case "page2":
                    vm.PageNumber = 2;
                    int destinationId = (int)TempData.Peek(nameof(Trip.DestinationId));
                    vm.DestinationName = data.Destinations.Get(destinationId).Name;

                    vm.Activities = data.Activities.List(new QueryOptions<Activity>
                    {
                        OrderBy =a => a.Name
                    });

                    return View("Page2", vm);

     
                case "page1":
                default:
                    vm.PageNumber = 1;
                    vm.Destinations = data.Destinations.List(new QueryOptions<Destination>
                    {
                        OrderBy = d => d.Name
                    });
                    vm.Accommodations = data.Accommodations.List(new QueryOptions<Accommodation>
                    {
                        OrderBy = a => a.Name
                    });
                    return View("Page1", vm);                    
            }
        }
        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            switch (vm.PageNumber)
            {
                case 1:
                    if (!ModelState.IsValid)
                    {
                        vm.Destinations = data.Destinations.List(new QueryOptions<Destination>
                        {
                            OrderBy = d => d.Name
                        });
                        vm.Accommodations = data.Accommodations.List(new QueryOptions<Accommodation>
                        {
                            OrderBy = a => a.Name
                        });

                        return View("Page1", vm);
                    }
                    TempData[nameof(Trip.DestinationId)] = vm.Trip.DestinationId;
                    TempData[nameof(Trip.StartDate)] = vm.Trip.StartDate;
                    TempData[nameof(Trip.EndDate)] = vm.Trip.EndDate;

                    if(vm.Trip.AccommodationId > 0)
                    {
                        TempData[nameof(Trip.AccommodationId)] = vm.Trip.AccommodationId;
                    }

                    return RedirectToAction("Add", new { id = "Page2" });
                    
                case 2:
                    vm.Trip = new Trip
                    {
                        DestinationId = (int)TempData[nameof(Trip.DestinationId)],
                        StartDate = (DateTime)TempData[nameof(Trip.StartDate)],
                        EndDate = (DateTime)TempData[nameof(Trip.EndDate)]
                    };

                    if (TempData.Keys.Contains(nameof(Trip.AccommodationId)))
                    {
                        vm.Trip.AccommodationId = (int)TempData[nameof(Trip.AccommodationId)];
                    }

                    foreach (int activityId in vm.SelectedActivities)
                    {
                        if (vm.Trip.TripActivities == null)
                        {
                            vm.Trip.TripActivities = new List<TripActivity>();
                        }
                        vm.Trip.TripActivities.Add(new TripActivity { ActivityId = activityId });
                    }

                    data.Trips.Insert(vm.Trip);
                    data.Save();

                    Destination destination = data.Destinations.Get(vm.Trip.DestinationId);

    

                    TempData["message"] = $"Trip to {destination.Name} added.";
                    return RedirectToAction("Index", "Home");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
        public RedirectToActionResult Delete(int id)
        {
            Trip trip = data.Trips.Get(id);
            Destination destination = data.Destinations.Get(trip.DestinationId);

            data.Trips.Delete(trip);
            data.Save();
            TempData["message"] = $"Trip to {destination.Name} deleted.";
            return RedirectToAction("Index", "Home");
        }
    }
}









