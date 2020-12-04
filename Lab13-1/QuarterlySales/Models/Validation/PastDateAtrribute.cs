using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models.Validation
{
    public class PastDateAtrribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                DateTime datetoCheck = (DateTime)value;
                if(datetoCheck < DateTime.Today)
                {
                    return ValidationResult.Success;
                }
            }
            string message = base.ErrorMessage ?? $"{validationContext.DisplayName} must be a valid past date.";
            return new ValidationResult(message);
        }
    }
}
