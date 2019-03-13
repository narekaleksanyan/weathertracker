using System.Threading.Tasks;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.GetLocation
{
    public interface ILoadLocationUseCase
    {
        Task<LoadLocationOutput> Execute(string name);
    }
}