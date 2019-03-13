using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices.Dtos;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService
{
    public class ExternalForecastService : ExternalRestServiceBase, IExternalForecastService
    {
        public ExternalForecastService(IRestServiceSettings settings) : base(settings)
        {
        }

        public async Task<ForecastDto> GetForecast(decimal longitude, decimal latitude)
        {
            throw new System.NotImplementedException();
        }
    }
}