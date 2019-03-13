using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadForecasts
{
    [DataContract]
    public class ForecastItem
    {
        [DataMember] public int LocationId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public decimal Longitude { get; set; }
        [DataMember] public decimal Latitude { get; set; }
        [DataMember] public  string Wind { get; set; }
        [DataMember] public string Humidity { get; set; }
    }
}