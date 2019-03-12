using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadLocations
{
    [DataContract]
    public class LocationItem
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public  double Latitude { get; set; }
        [DataMember] public  double Longitude { get; set; }
    }
}