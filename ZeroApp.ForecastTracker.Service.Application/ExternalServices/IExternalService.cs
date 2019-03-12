using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService.Dtos;

namespace ZeroApp.ForecastTracker.Service.Application.ExternalServices
{
    public interface IExternalService
    {
        Task<GeoLocationDto> GetGeoLocationByName(string name);
        Task<ForecastDto> GetForecast(decimal longitude, decimal latitude);
    }

    public interface IConfigurationManager
    {
        string GeoLocationApiKey { get;  }

        string GeoLocationBaseUrl { get; }
    }
}