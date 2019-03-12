using System.Collections.Generic;
using System.Runtime.Serialization;


namespace ZeroApp.ForecastTracker.Service.Contracts.LoadLocations
{
    [DataContract]
    public class LoadLocationsResponse
    {
        [DataMember] public List<LocationItem> Locations { get; set; }
    }
}