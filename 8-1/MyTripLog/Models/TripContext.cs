using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace MyTripLog.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            : base(options) { }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "Austin",
                    StartDate = Convert.ToDateTime("10/31/2002"),
                    EndDate = Convert.ToDateTime("11/5/2002"),
                    Accommodation = "Holiday Inn",
                    AccommodationPhone = "555-555-5555",
                    AccommodationEmail = "autinholidayinn@email.com",
                    ThingToDo1 = "Music Festival",
                    ThingToDo2 = "Sweat a lot",
                    ThingToDo3 = "BBQ Food"


                }
                );
        }
    }
}
