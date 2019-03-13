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

        public Task<SaveLocationResponse> SaveLocationAsync(SaveLocationRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<LoadLocationResponse> LoadLocationAsync(LoadLocationRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<LoadLocationForecastResponse> LoadLocationForecastAsync(LoadLocationForecastRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
