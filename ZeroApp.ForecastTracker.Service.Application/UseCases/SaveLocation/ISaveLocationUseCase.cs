using System.Threading.Tasks;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.SaveLocation
{
    public interface ISaveLocationUseCase
    {
        Task<int> Execute(string name, double longitude, double latitude);
    }
}