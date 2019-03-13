using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Application.Repositories;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocationForecast
{
    public class LoadLocationForecastUseCase : ILoadLocationForecastUseCase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IGeoLocationService _geoLocationService;

        public LoadLocationForecastUseCase(ILocationRepository locationRepository,
            IGeoLocationService geoLocationService)
        {
            _locationRepository = locationRepository;
            _geoLocationService = geoLocationService;
        }

        public async Task<LoadLocationForecastOutput> Execute(string name)
        {
            var location = await _locationRepository.GetLocationByName(name);
            if (location == null) // this is business case check not exception handling
            {
                var locationResponse = await _geoLocationService.GetGeoLocationByName(name);
                if (locationResponse == null)
                {
                    await _locationRepository.SaveLocation(name, 0, 0);

                    return new LoadLocationForecastOutput {Humidity = "-", Wind = "-"};
                }


            }


            return new LoadLocationForecastOutput();
        } 
    }
}