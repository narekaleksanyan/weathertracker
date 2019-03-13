using ZeroApp.ForecastTracker.Service.Application.UseCases.GetLocation;
using ZeroApp.ForecastTracker.Service.Application.UseCases.LoadForecasts;
using ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Application.UseCases.SaveLocation;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases
{
    public interface IUseCaseFactory
    {
        ILoadLocationForecastUseCase LoadLocationForecastUseCase { get; }
        ILoadLocationUseCase LoadLocationUseCase { get; }
        ILoadForecastsUseCase LoadForecastsUseCase { get; }
        ISaveLocationUseCase SaveLocationUseCase { get; }
    }

    public class UseCaseFactory : IUseCaseFactory
    {
        public UseCaseFactory(
            ILoadLocationForecastUseCase loadLocationForecastUseCase,
            ILoadLocationUseCase loadLocationsUseCase,
            ILoadForecastsUseCase loadForecastsUseCase,
            ISaveLocationUseCase saveLocationUseCase)
        {
            LoadLocationForecastUseCase = loadLocationForecastUseCase;
            LoadLocationUseCase = loadLocationsUseCase;
            LoadForecastsUseCase = loadForecastsUseCase;
            SaveLocationUseCase = saveLocationUseCase;
        }

        public ILoadLocationForecastUseCase LoadLocationForecastUseCase { get; }
        public ILoadLocationUseCase LoadLocationUseCase { get; }
        public ILoadForecastsUseCase LoadForecastsUseCase { get; }
        public ISaveLocationUseCase SaveLocationUseCase { get; }
    }
}