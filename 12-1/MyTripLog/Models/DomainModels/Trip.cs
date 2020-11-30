using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyTripLog.Models;

namespace MyTripLog.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Range(1, 99999999999, ErrorMessage ="Please enter a Destination")]
        public int DestinationId { get; set; } 
        public Destination Destination { get; set; }

        [Required(ErrorMessage ="Please enter a start date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a end date")]
        public DateTime? EndDate { get; set; }

        public int? AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }

        public ICollection<TripActivity> TripActivities { get; set; }


    }
}
