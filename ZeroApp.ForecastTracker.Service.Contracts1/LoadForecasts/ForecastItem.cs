using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadForecasts
{
    [DataContract]
    public class ForecastItem
    {
        [DataMember] public int LocationId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public double Longitude { get; set; }
        [DataMember] public double Latitude { get; set; }
        [DataMember] public float Wind { get; set; }
        [DataMember] public float Humidity { get; set; }
        [DataMember] public float Temperature { get; set; }
        [DataMember] public string Timezone { get; set; }
        [DataMember] public long Time { get; set; }
        [DataMember] public string Summary { get; set; }
    }
}