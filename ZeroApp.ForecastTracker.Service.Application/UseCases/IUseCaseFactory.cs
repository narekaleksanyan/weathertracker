using ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocations;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases
{
    public interface IUseCaseFactory
    {
        ILoadLocationForecastUseCase LoadLocationForecastUseCase { get; }

        ILoadLocationsUseCase LoadLocationsUseCase { get; }
    }

    public class UseCaseFactory : IUseCaseFactory
    {
        public UseCaseFactory(ILoadLocationForecastUseCase loadLocationForecastUseCase,
            ILoadLocationsUseCase loadLocationsUseCase)
        {
            LoadLocationForecastUseCase = loadLocationForecastUseCase;
            LoadLocationsUseCase = loadLocationsUseCase;
        }

        public ILoadLocationForecastUseCase LoadLocationForecastUseCase { get; }

        public ILoadLocationsUseCase LoadLocationsUseCase { get; }
    }
}