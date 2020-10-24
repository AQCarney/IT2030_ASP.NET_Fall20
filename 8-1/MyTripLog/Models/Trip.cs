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
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a end date")]
        public DateTime? EndDate { get; set; }

        public string Accommodation { get; set; }
        public string AccommodationPhone { get; set; }
        public string AccommodationEmail { get; set; }
        public string ThingToDo1 { get; set; }
        public string ThingToDo2 { get; set; }
        public string ThingToDo3 { get; set; }
    }
}
