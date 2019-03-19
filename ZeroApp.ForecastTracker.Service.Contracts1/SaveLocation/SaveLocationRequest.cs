using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.SaveLocation
{
    [DataContract]
    public class SaveLocationRequest
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public double Longitude { get; set; }
        [DataMember] public double Latitude { get; set; }
    }
}