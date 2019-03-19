using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadLocation
{
    [DataContract]
    public class LoadLocationResponse
    {
        [DataMember] public int? Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public double Longitude { get; set; }
        [DataMember] public double Latitude { get; set; }
        [DataMember] public int StatusCode { get; set; }
    }
}