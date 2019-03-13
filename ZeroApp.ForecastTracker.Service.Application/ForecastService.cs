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

            return new LoadLocationResponse();
        }

        public async Task<LoadLocationForecastResponse> LoadLocationForecastAsync(LoadLocationForecastRequest request)
        {
            var output = await _useCaseFactory.LoadLocationForecastUseCase.Execute(request.LocationId);
            return new LoadLocationForecastResponse { };
        }

        public async Task<LoadForecastsResponse> LoadForecastsAsync(LoadForecastsRequest request)
        {
            var output = await _useCaseFactory.LoadForecastsUseCase.Execute();
            return new LoadForecastsResponse
            {
                ForecastItems = output.Forecasts.Select(x => new ForecastItem
                {
                    Longitude = x.Location.Longitude,
                    Latitude = x.Location.Latitude,
                    Name = x.Location.Name,
                    LocationId = x.Location.Id,
                    Wind =  x.Wind,
                    Humidity = x.Humidity
                }).ToList()
            };
        }

        public async Task<SaveLocationResponse> SaveLocationAsync(SaveLocationRequest request)
        {
            await _useCaseFactory.SaveLocationUseCase.Execute(request.Name, request.Longitude, request.Latitude);
            return new SaveLocationResponse();
        }
    }
}
