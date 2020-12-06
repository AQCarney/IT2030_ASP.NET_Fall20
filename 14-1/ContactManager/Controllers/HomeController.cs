using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<Contact> data { get; set; }
        public HomeController(IRepository<Contact> rep)
        {
            this.data = rep;
        }

        public IActionResult Index()
        {
            var options = new QueryOptions<Contact>
            {
                Includes = "Category",
                OrderBy = c => c.Fname
            };

            var contacts = data.List(options);
            return View(contacts);
        }
    }
}
