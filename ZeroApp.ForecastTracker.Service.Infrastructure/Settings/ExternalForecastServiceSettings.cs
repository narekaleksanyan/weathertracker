using System.Web.Configuration;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.Settings
{
    public class ExternalForecastServiceSettings : IForecastServiceSettings
    {
        public string ApiKey => WebConfigurationManager.AppSettings["DarkApiKey"];
    }
}