using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    public class ValidationController : Controller
    {
        private UnitOfWork data { get; set; }
        public ValidationController(SalesContext ctx) => this.data = new UnitOfWork(ctx);
        public JsonResult CheckEmployee(string firstName, string lastName, DateTime dateOfBirth)
        {
            Employee employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };
            string message = Validate.CheckEmployee(data.Employees, employee);
            if (string.IsNullOrEmpty(message))
            {
                return Json(true);
            }
            return Json(message);
        }
        public JsonResult CheckManager(int managerId, string firstName, string lastName, DateTime dateOfBirth)
        {
            Employee employee = new Employee
            {
                ManagerId = managerId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };
            string message = Validate.CheckManagerEmployeeMatch(data.Employees, employee);
            if (string.IsNullOrEmpty(message))
            {
                return Json(true);
            }
            return Json(message);

        }
        public JsonResult CheckSales(int employeeId, int year, int quarter)
        {
            Sales sale = new Sales
            {
                EmployeeId = employeeId,
                Year = year,
                Quarter = quarter
            };
            string message = Validate.CheckSales(data, sale);
            if (string.IsNullOrEmpty(message))
            {
                return Json(true);
            }
            return Json(message);

        }
        

        }

    }

