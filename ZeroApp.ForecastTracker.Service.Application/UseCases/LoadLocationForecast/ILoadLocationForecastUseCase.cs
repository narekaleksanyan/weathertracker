using System.Threading.Tasks;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocationForecast
{
    public interface ILoadLocationForecastUseCase
    {
        Task<LoadLocationForecastOutput> Execute(string name);
    }
}