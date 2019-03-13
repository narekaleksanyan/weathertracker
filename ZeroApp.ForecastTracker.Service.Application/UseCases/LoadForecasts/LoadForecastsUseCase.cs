using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices.Dtos;
using ZeroApp.ForecastTracker.Service.Application.Repositories;
using ZeroApp.ForecastTracker.Service.Domain.Location;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadForecasts
{
    public class LoadForecastsUseCase : ILoadForecastsUseCase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IExternalForecastService _externalForecastService;

        public LoadForecastsUseCase(ILocationRepository locationRepository,
            IExternalForecastService externalForecastService)
        {
            _locationRepository = locationRepository;
            _externalForecastService = externalForecastService;
        }

        public async Task<LoadForecastsOutput> Execute()
        {
            var locations = await _locationRepository.GetAllLocations();
            var forecasts = new List<ForecastDto>();
            Parallel.ForEach(locations, async x =>
            {
               var forecast = await  _externalForecastService.GetForecast(x.Longitude, x.Latitude);
               forecast.Latitude = x.Latitude;
               forecast.Longitude = x.Longitude;
               forecast.Name = x.Name;
               forecast.Id = x.Id;
               forecasts.Add(forecast);
            });

            return new LoadForecastsOutput
            {
                Forecasts = forecasts.Select(x =>
                    Location.Load(x.Id, x.Name, x.Longitude, x.Latitude,
                        new Forecast {Wind = x.Wind, Humidity = x.Humidity})
                ).ToList()
            };
        }
    }
}