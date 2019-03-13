using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ZeroApp.ForecastTracker.Service.Contracts.LoadForecasts
{
    [DataContract]
    public class LoadForecastsResponse
    {
        [DataMember] public List<ForecastItem> ForecastItems { get; set; }
    }
}