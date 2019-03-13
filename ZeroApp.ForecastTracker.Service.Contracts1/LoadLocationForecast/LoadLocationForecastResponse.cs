﻿using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast
{
    [DataContract]
    public class LoadLocationForecastResponse
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public decimal Longitude { get; set; }
        [DataMember] public decimal Latitude { get; set; }
        [DataMember] public string Wind { get; set; }
        [DataMember] public string Humidity { get; set; }
    }
}