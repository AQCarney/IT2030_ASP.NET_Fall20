using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2_1.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter a subtotal ")]
        [Range(1, int.MaxValue, ErrorMessage = "Subtotal must be greater than zero")]
        public decimal? Subtotal { get; set; }
        [Required(ErrorMessage = "Please enter a discount percentage")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        public decimal? DiscountPercent { get; set; }
        public decimal? CalculateDiscountAmount()
        {
            decimal? discountAmount = Subtotal * (DiscountPercent / 100);
            return (decimal)discountAmount;
        }
        public decimal? CalculateTotal()
        {
            decimal? total = Subtotal - (Subtotal * (DiscountPercent / 100));
            return (decimal)total;
        }


    }
}
