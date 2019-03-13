using RestSharp;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService.Dtos;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService
{
    public class GeoLocationService : ExternalRestServiceBase, IGeoLocationService
    {
        public GeoLocationService(IRestServiceSettings settings) : base(settings)
        {
        }
   
        public async Task<GeoLocationDto> GetGeoLocationByName(string name)
        {
            var url = BuildGetGeoLocationUrl(name);
            var client = new RestClient(url);
            var request = new RestRequest("", Method.GET);
            var response = await client.GetAsync<GeoLocationDto>(request);
            return response;
        }

        private  string BuildGetGeoLocationUrl(string name)
        {
            return $"{Settings.BaseAddress}?q={name}&key={Settings.ApiKey}";
        }
    }
}
