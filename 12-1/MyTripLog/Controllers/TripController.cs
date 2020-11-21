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
        private TripContext context { get; set; }
        public TripController(TripContext context) => this.context = context;

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ViewResult Add(string id)
        {
            TripViewModel vm = new TripViewModel();
            switch (id?.ToLower())
            {
                case "page2":

                    string accommodation = TempData[nameof(Trip.Accommodation)]?.ToString();

                    if (string.IsNullOrWhiteSpace(accommodation))
                    {
                        vm.PageNumber = 3;
                        string destination = TempData.Peek(nameof(Trip.Destination)).ToString();
                        vm.Trip = new Trip { Destination = destination };
                        return View("Page3", vm);
                    }

                    vm.PageNumber = 2;
                    vm.Trip = new Trip { Accommodation = accommodation };
                    TempData.Keep(nameof(Trip.Accommodation));
                    return View("Page2", vm);

                case "page3":
                    vm.PageNumber = 3;
                    vm.Trip = new Trip { Destination = TempData.Peek(nameof(Trip.Destination)).ToString() };
                    return View("Page3", vm);
                case "page1":
                default:
                    vm.PageNumber = 1;
                    return View("Page1", vm);                    
            }
        }
        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            switch (vm.PageNumber)
            {
                case 1:
                    if (!ModelState.IsValid){
                        return View("Page1", vm);
                    }
                    TempData[nameof(Trip.Destination)] = vm.Trip.Destination;
                    TempData[nameof(Trip.Accommodation)] = vm.Trip.Accommodation;
                    TempData[nameof(Trip.StartDate)] = vm.Trip.StartDate;
                    TempData[nameof(Trip.EndDate)] = vm.Trip.EndDate;
                    return RedirectToAction("Add", new { id = "Page2" });
                    
                case 2:
                    TempData[nameof(Trip.AccommodationPhone)] = vm.Trip.AccommodationPhone;
                    TempData[nameof(Trip.AccommodationEmail)] = vm.Trip.AccommodationEmail;
                    return RedirectToAction("Add", new { id = "Page3" });
                case 3:
                    vm.Trip.Destination = TempData[nameof(Trip.Destination)].ToString();
                    vm.Trip.Accommodation = TempData[nameof(Trip.Accommodation)]?.ToString();
                    vm.Trip.StartDate = (DateTime)TempData[nameof(Trip.StartDate)];
                    vm.Trip.EndDate = (DateTime)TempData[nameof(Trip.EndDate)];
                    vm.Trip.AccommodationPhone = TempData[nameof(Trip.AccommodationPhone)]?.ToString();
                    vm.Trip.AccommodationEmail = TempData[nameof(Trip.AccommodationEmail)]?.ToString();

                    context.Trips.Add(vm.Trip);
                    context.SaveChanges();

                    TempData["message"] = $"Trip to {vm.Trip.Destination} added.";
                    return RedirectToAction("Index", "Home");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
    }
}









