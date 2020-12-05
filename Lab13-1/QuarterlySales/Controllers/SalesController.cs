using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    public class SalesController : Controller
    {
        private UnitOfWork data{ get; set; }
        public SalesController(SalesContext ctx) => this.data = new UnitOfWork(ctx);
        public IActionResult Index() => RedirectToAction("Index", "Home");
        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Employees = data.Employees.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });
            return View();
        }
        [HttpPost]
        public IActionResult Add(Sales sales)
        {
            string message = Validate.CheckSales(data, sales);
            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(sales.EmployeeId), message);
            }
            if (ModelState.IsValid)
            {
                data.Sales.Insert(sales);
                data.Save();
                TempData["message"] = $"Sales added";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = data.Employees.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });
                return View();
            }
        }


    }
}
