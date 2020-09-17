using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2_2.Models
{
    public class TipCalculatorModel
    {
        [Required(ErrorMessage = "Please enter a meal amount")]
        [Range(1, int.MaxValue, ErrorMessage = "Meal amount must be greater than zero" )]
        public decimal? CostOfMeal { get; set; }
        public decimal? CalculateFT()
        {
            decimal? ft = CostOfMeal * 15 / 100;
            return (decimal)ft;
        }
        public decimal? CalculateTT()
        {
            decimal? tt = CostOfMeal * 20 / 100;
            return (decimal)tt;
        }
        public decimal? CalculateTF()
        {
            decimal? tf = CostOfMeal * 25 / 100;
            return (decimal)tf;
        }
    }
}
