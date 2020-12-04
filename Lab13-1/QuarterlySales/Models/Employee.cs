using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using QuarterlySales.Models.Validation;
using Microsoft.AspNetCore.Mvc;

namespace QuarterlySales.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a birth date.")]
        [PastDateAtrribute(ErrorMessage = "Birth date much be a valid date that's in the past.")]
        [Remote("CheckEmployee", "Validation", AdditionalFields = "FirstName, LastName")]
        [Display(Name = "Birth Date")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a hire date.")]
        [PastDateAtrribute(ErrorMessage = "Hire date much be a valid date that's in the past.")]
        [GreaterThanAtrribute("1/1/1995", ErrorMessage ="Hire date can't be before company was formed in 1995.")]
        [Display(Name = "Hire Date")]
        public DateTime? DateOfHire { get; set; }
        [GreaterThanAtrribute(0, ErrorMessage ="Please select a manager.")]
        [Remote("CheckManager", "Validation", AdditionalFields = "FirstName, LastName, DateOfBirth")]
        [Display(Name = "Manager")]
        public int ManagerId { get; set; }
        public string FullName => $"{FirstName} {LastName}";

    }
}
