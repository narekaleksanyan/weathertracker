using System.ServiceModel;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocations;

namespace ZeroApp.ForecastTracker.Service.Contracts
{
    [ServiceContract]
    public interface IForeCastService
    {
        [OperationContract]
        LoadLocationsResponse LoadLocations(LoadLocationsRequest request);

        [OperationContract]
        LoadLocationForecastResponse LoadLocationForecast(LoadLocationForecastRequest request);

    }
}
