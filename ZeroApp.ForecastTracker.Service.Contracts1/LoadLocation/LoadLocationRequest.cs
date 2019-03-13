using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadLocation
{
    [DataContract]
    public class LoadLocationRequest
    {
        public string Name { get; set; }
    }
}