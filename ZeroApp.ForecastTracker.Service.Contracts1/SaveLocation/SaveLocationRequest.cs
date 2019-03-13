using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.SaveLocation
{
    [DataContract]
    public class SaveLocationRequest
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public decimal Longitude { get; set; }
        [DataMember] public decimal Latitude { get; set; }
    }
}