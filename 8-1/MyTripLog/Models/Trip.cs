using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTripLog.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        [Required(ErrorMessage ="Please enter a Destination")]
        public string Destination { get; set; }
        [Required(ErrorMessage ="Please enter a start date")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999",
            ErrorMessage ="Start date must be after 1/1/1900.")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Please enter a end date")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999",
            ErrorMessage = "End date must be before 12/31/9999.")]
        public DateTime? EndDate { get; set; }
        public string Accommodation { get; set; }
        public string AccommodationPhone { get; set; }
        public string AccommodationEmail { get; set; }
        public string ThingToDo1 { get; set; }
        public string ThingToDo2 { get; set; }
        public string ThingToDo3 { get; set; }
    }
}
