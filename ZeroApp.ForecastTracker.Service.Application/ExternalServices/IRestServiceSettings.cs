namespace ZeroApp.ForecastTracker.Service.Application.ExternalServices
{
    public interface IRestServiceSettings
    {
        string ApiKey { get; }
        string BaseAddress { get; }
    }
}