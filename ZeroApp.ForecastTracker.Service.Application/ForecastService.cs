using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.UseCases;
using ZeroApp.ForecastTracker.Service.Contracts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocations;

namespace ZeroApp.ForecastTracker.Service.Application
{
    public class ForecastService : IForeCastService
    {
        private readonly IUseCaseFactory _useCaseFactory;

        public ForecastService(IUseCaseFactory useCaseFactory)
        {
            _useCaseFactory = useCaseFactory;
        }

        public async Task<LoadLocationsResponse> LoadLocationsAsync(LoadLocationsRequest request)
        {
            var output = await _useCaseFactory.LoadLocationsUseCase.Execute();
            return new LoadLocationsResponse();
        }

        public async Task<LoadLocationForecastResponse> LoadLocationForecastAsync(LoadLocationForecastRequest request)
        {
            var output = await _useCaseFactory.LoadLocationForecastUseCase.Execute(request.Name);
            return new LoadLocationForecastResponse { };
        }
    }
}
