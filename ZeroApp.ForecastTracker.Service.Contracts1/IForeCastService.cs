using System.ServiceModel;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocations;

namespace ZeroApp.ForecastTracker.Service.Contracts
{
    [ServiceContract]
    public interface IForeCastService
    {
        [OperationContract]
        Task<LoadLocationsResponse> LoadLocationsAsync(LoadLocationsRequest request);

        [OperationContract]
        Task<LoadLocationForecastResponse> LoadLocationForecastAsync(LoadLocationForecastRequest request);
    }
}
