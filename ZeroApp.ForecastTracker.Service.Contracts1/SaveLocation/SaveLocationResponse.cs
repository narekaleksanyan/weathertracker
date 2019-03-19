using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.SaveLocation
{
    [DataContract]
    public class SaveLocationResponse
    {
        [DataMember] public int LocationId { get; set; }
    }
}