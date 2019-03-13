using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Application.Repositories;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocationForecast
{
    public class LoadLocationForecastUseCase : ILoadLocationForecastUseCase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IExternalForecastService _externalForecastService;

        public LoadLocationForecastUseCase(ILocationRepository locationRepository,
            IExternalForecastService externalForecastService)
        {
            _locationRepository = locationRepository;
            _externalForecastService = externalForecastService;
        }

        public async Task<LoadLocationForecastOutput> Execute(int id)
        {
            var location = await _locationRepository.GetLocationById(id);
            var forecast = await _externalForecastService.GetForecast(location.Longitude, location.Latitude);

            
            return new LoadLocationForecastOutput();
        } 
    }
}