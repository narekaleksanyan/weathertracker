using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices.Dtos;

namespace ZeroApp.ForecastTracker.Service.Application.ExternalServices
{
    public interface IExternalForecastService
    {
        Task<ForecastDto> GetForecast(decimal longitude, decimal latitude);
    }
}