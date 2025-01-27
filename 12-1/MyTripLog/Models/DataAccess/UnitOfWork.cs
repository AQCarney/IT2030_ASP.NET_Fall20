﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyTripLog.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private TripContext context { get; set; }
        public UnitOfWork(TripContext ctx) => context = ctx;
        private Repository<Trip> trips;
        public Repository<Trip> Trips
        {
            get
            {
                if (trips == null)
                {
                    trips = new Repository<Trip>(context);
                }
                return trips;
            }
        }

        private Repository<Destination> destinations;
        public Repository<Destination> Destinations
        {
            get
            {
                if (destinations == null)
                {
                    destinations = new Repository<Destination>(context);
                }
                return destinations;
            }
        }

        private Repository<Accommodation> accommodation;
        public Repository<Accommodation> Accommodations
        {
            get
            {
                if (accommodation == null)
                {
                    accommodation = new Repository<Accommodation>(context);
                }
                return accommodation;
            }
        }

        private Repository<Activity> activities;
        public Repository<Activity> Activities
        {
            get
            {
                if (activities == null)
                {
                    activities = new Repository<Activity>(context);
                }
                return activities;
            }
        }

        public void Save() => context.SaveChanges();

    }
}
