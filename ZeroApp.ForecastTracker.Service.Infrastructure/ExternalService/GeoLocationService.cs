using OpenCage.Geocode;
using System.Linq;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices.Dtos;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService
{
    public class GeoLocationService :  IGeoLocationService
    {
        private readonly IGeoLocationServiceSettings _settings;
        public GeoLocationService(IGeoLocationServiceSettings settings)
        {
            _settings = settings;
        }

        public async Task<GeoLocationDto> GetGeoLocationByName(string name)
        {
            var response = await CallApi(_settings.ApiKey, name);
            if (response.Status.Code != 200)
            {
                return new GeoLocationDto {StatusCode = 500};
            }

            if (!response.Results.Any())
            {
                return new GeoLocationDto {StatusCode = 404};
            }

            var longitude = response.Results.First().Geometry.Longitude;
            var latitude = response.Results.First().Geometry.Latitude;

            return new GeoLocationDto {StatusCode = 200, Longitude = longitude, Latitude = latitude};
        }

        private static async Task<GeocoderResponse> CallApi(string apiKey, string query)
        {
            GeocoderResponse response = null;
            var gc = new Geocoder(apiKey);
            await Task.Run(() => { response = gc.Geocode(query); });
            return response;
        }
    }
}
