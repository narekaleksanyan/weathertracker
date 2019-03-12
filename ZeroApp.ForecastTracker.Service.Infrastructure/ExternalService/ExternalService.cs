using System;
using System.Threading.Tasks;
using RestSharp;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService.Dtos;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService
{
    public class ExternalService : IExternalService
    {
        private readonly IConfigurationManager _configurationManager;

        public ExternalService(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public async Task<GeoLocationDto> GetGeoLocationByName(string name)
        {
            var url = BuildGetGeoLocationUrl(name, _configurationManager.GeoLocationApiKey,
                _configurationManager.GeoLocationBaseUrl);
            var client = new RestClient(url);
            var request = new RestRequest("", Method.GET);
            var response = await client.GetAsync<GeoLocationDto>(request);
            return response;
        }

        public Task<ForecastDto> GetForecast(decimal longitude, decimal latitude)
        {
            throw new NotImplementedException();
        }

        private static string BuildGetGeoLocationUrl(string name,string apiKey,string baseUrl)
        {
            return $"{baseUrl}?q={name}&key={apiKey}";
        }

        private static string BuildForecastUrl(string apiKey, string baseUrl)
        {
            throw new NotImplementedException();
        }
    }
}