using System.Threading.Tasks;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadForecasts
{
    public interface ILoadForecastsUseCase
    {
        Task<LoadForecastsOutput> Execute();
    }
}