using System.Threading.Tasks;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.SaveLocation
{
    public interface ISaveLocationUseCase
    {
        Task Execute(string name, decimal longitude, decimal latitude);
    }
}