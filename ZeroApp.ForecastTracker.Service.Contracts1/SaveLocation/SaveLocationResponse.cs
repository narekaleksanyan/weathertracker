using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.SaveLocation
{
    [DataContract]
    public class SaveLocationResponse
    {
        public int LocationId { get; set; }
    }
}