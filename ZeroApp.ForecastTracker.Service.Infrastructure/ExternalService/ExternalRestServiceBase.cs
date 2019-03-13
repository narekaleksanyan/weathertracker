using ZeroApp.ForecastTracker.Service.Application.ExternalServices;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService
{
    public abstract class ExternalRestServiceBase
    {
        protected ExternalRestServiceBase(IRestServiceSettings settings)
        {
            Settings = settings;
        }

        protected IRestServiceSettings Settings { get; }
    }
}
