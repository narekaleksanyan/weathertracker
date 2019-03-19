using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadLocation
{
    [DataContract]
    public class LoadLocationRequest
    {
        [DataMember] public string Name { get; set; }
    }
}