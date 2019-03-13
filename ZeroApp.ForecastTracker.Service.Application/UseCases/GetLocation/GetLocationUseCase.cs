using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Application.Repositories;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.GetLocation
{
    public class LoadLocationUseCase : ILoadLocationUseCase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IGeoLocationService _geoLocationService;

        public LoadLocationUseCase(ILocationRepository locationRepository, IGeoLocationService geoLocationService)
        {
            _locationRepository = locationRepository;
            _geoLocationService = geoLocationService;
        }

        public async Task<LoadLocationOutput> Execute(string name)
        {
            var location = await _locationRepository.GetLocationByName(name);
            if (location != null)
            {
                return new LoadLocationOutput {Location = location};
            }

            var response = await _geoLocationService.GetGeoLocationByName(name);
            if (response == null)
            {
                return new LoadLocationOutput {IsFromApi = true};
            }

            return new LoadLocationOutput {IsFromApi = true};
        }
    }
}