using System.Linq;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.UseCases;
using ZeroApp.ForecastTracker.Service.Contracts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadForecasts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocation;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Contracts.SaveLocation;

namespace ZeroApp.ForecastTracker.Service.Application
{
    public class ForecastService : IForeCastService
    {
        private readonly IUseCaseFactory _useCaseFactory;

        public ForecastService(IUseCaseFactory useCaseFactory)
        {
            _useCaseFactory = useCaseFactory;
        }

        public async Task<LoadLocationResponse> LoadLocationAsync(LoadLocationRequest request)
        {
            var output = await _useCaseFactory.LoadLocationUseCase.Execute(request.Name);
            return new LoadLocationResponse
            {
                Longitude = output.Longitude,
                Latitude = output.Latitude,
                Name = output.Name,
                Id = output.Id,
                StatusCode = output.StatusCode
            };
        }

        public async Task<LoadLocationForecastResponse> LoadLocationForecastAsync(LoadLocationForecastRequest request)
        {
            var output = await _useCaseFactory.LoadLocationForecastUseCase.Execute(request.LocationId);
            return new LoadLocationForecastResponse
            {
                Longitude = output.Longitude,
                Latitude = output.Latitude,
                Id = output.LocationId,
                Name = output.LocationName,
                Wind = output.Wind,
                Humidity = output.Humidity,
                Time = output.Time,
                Summary = output.Summary,
                Timezone = output.Timezone,
                Temperature = output.Temperature
            };
        }

        public async Task<LoadForecastsResponse> LoadForecastsAsync(LoadForecastsRequest request)
        {
            var output = await _useCaseFactory.LoadForecastsUseCase.Execute();
            return new LoadForecastsResponse
            {
                ForecastItems = output.Forecasts.Select(x => new ForecastItem
                {
                    Longitude = x.Longitude,
                    Latitude = x.Latitude,
                    Name = x.Name,
                    LocationId = x.Id,
                    Wind = x.Forecast.Wind,
                    Humidity = x.Forecast.Humidity,
                    Time = x.Forecast.Time,
                    Summary = x.Forecast.Summary,
                    Temperature = x.Forecast.Temperature,
                    Timezone = x.Forecast.Timezone
                }).ToList()
            };
        }

        public async Task<SaveLocationResponse> SaveLocationAsync(SaveLocationRequest request)
        {
            var id = await _useCaseFactory.SaveLocationUseCase.Execute(request.Name, request.Longitude,
                request.Latitude);
            return new SaveLocationResponse {LocationId = id};
        }
    }
}
