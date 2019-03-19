using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Contracts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadForecasts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocation;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Contracts.SaveLocation;

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

        public ForecastServiceClient(string endpointConfigurationName,
            System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public ForecastServiceClient(System.ServiceModel.Channels.Binding binding,
            System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public async Task<LoadForecastsResponse> LoadForecastsAsync(LoadForecastsRequest request)
        {
            return await Channel.LoadForecastsAsync(request);
        }

        public async Task<SaveLocationResponse> SaveLocationAsync(SaveLocationRequest request)
        {
            return await Channel.SaveLocationAsync(request);
        }

        public async Task<LoadLocationResponse> LoadLocationAsync(LoadLocationRequest request)
        {
            return await Channel.LoadLocationAsync(request);
        }

        public async Task<LoadLocationForecastResponse> LoadLocationForecastAsync(LoadLocationForecastRequest request)
        {
            return await Channel.LoadLocationForecastAsync(request);
        }
    }
}
