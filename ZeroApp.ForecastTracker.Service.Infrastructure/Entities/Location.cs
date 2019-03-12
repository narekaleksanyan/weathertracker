﻿namespace ZeroApp.ForecastTracker.Service.Infrastructure.Entities
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}