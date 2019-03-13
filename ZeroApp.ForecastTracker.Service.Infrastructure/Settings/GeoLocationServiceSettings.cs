using ZeroApp.ForecastTracker.Service.Application.ExternalServices;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.Settings
{
    public class GeoLocationServiceSettings : IRestServiceSettings
    {
        public string ApiKey { get; }
        public string BaseAddress { get; }
    }
}
