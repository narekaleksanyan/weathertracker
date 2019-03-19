using ForecastIO;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices.Dtos;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService
{
    public class ExternalForecastService : IExternalForecastService
    {
        private readonly IForecastServiceSettings _settings;

        public ExternalForecastService(IForecastServiceSettings settings)
        {
            _settings = settings;
        }

        public async Task<ForecastDto> GetForecast(double longitude, double latitude)
        {
            var request = new ForecastIORequest(_settings.ApiKey, (float) latitude, (float) longitude, Unit.si);
            var response = await request.GetAsync();
            if (response?.currently != null)
            {            
                return new ForecastDto
                {
                    StatusCode = 200,
                    Humidity = response.currently.humidity,
                    Wind = response.currently.windSpeed,
                    Timezone = response.timezone,
                    Time = response.currently.time,
                    Summary = response.currently.summary,
                    Temperature = response.currently.temperature
                };
            }

            return new ForecastDto {StatusCode = 404};
        }
    }
}