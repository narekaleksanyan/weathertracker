using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Contracts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocations;

namespace ZeroApp.ForecastTracker.Client.Services
{
    public class ForecastServiceClient : System.ServiceModel.ClientBase<IForeCastService>, IForeCastService
    {
        public ForecastServiceClient()
        {
        }

        public ForecastServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public ForecastServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public ForecastServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public ForecastServiceClient(System.ServiceModel.Channels.Binding binding,
            System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public async Task<LoadLocationsResponse> LoadLocationsAsync(LoadLocationsRequest request)
        {
            return await Channel.LoadLocationsAsync(request);
        }

        public async Task<LoadLocationForecastResponse> LoadLocationForecastAsync(LoadLocationForecastRequest request)
        {
            return await Channel.LoadLocationForecastAsync(request);
        }
    }
}
