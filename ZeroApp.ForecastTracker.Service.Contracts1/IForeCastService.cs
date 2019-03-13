using System.ServiceModel;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Contracts.LoadForecasts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocation;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Contracts.SaveLocation;

namespace ZeroApp.ForecastTracker.Service.Contracts
{
    [ServiceContract]
    public interface IForeCastService
    {
        [OperationContract]
        Task<LoadForecastsResponse> LoadForecastsAsync(LoadForecastsRequest request);

        [OperationContract]
        Task<SaveLocationResponse> SaveLocationAsync(SaveLocationRequest request);

        [OperationContract]
        Task<LoadLocationResponse> LoadLocationAsync(LoadLocationRequest request);

        [OperationContract]
        Task<LoadLocationForecastResponse> LoadLocationForecastAsync(LoadLocationForecastRequest request);
    }
}
