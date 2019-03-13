using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadLocation
{
    [DataContract]
    public class LoadLocationResponse
    {
        [DataMember] public int? Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public decimal Longitude { get; set; }
        [DataMember] public decimal Latitude { get; set; }
    }
}