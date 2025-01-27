﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QuarterlySales.Models
{
    public class Sales
    {
        public int SalesId { get; set; }
        [Required(ErrorMessage = "Please enter a quarter.")]
        [Range(1,4, ErrorMessage = "Quarter must be between 1 and 4.")]
        public int? Quarter { get; set; }
        [Required(ErrorMessage = "Please enter a year.")]
        [GreaterThanAtrribute(2000, ErrorMessage ="Year must be before 2000.")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please enter an amount.")]
        [GreaterThanAtrribute(0.0, ErrorMessage ="Amount must be greater than zero.")]
        public double? Amount { get; set; }
        [GreaterThanAtrribute(0, ErrorMessage ="Please select an employee.")]
        [Remote("CheckSales", "Validation", AdditionalFields ="Quarter, Year")]
        [Display(Name = "Employee")]

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
