﻿using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast
{
    [DataContract]
    public class LoadLocationForecastRequest
    {
        [DataMember] public string Name { get; set; }
    }
}
