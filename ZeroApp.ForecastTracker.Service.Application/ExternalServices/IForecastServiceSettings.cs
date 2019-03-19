namespace ZeroApp.ForecastTracker.Service.Application.ExternalServices
{
    public interface IForecastServiceSettings : IExternalServiceSettings
    {
    }

    public interface IGeoLocationServiceSettings : IExternalServiceSettings
    {

    }

    public interface IExternalServiceSettings
    {
        string ApiKey { get; }
    }
}