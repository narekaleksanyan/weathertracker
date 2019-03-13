using ZeroApp.ForecastTracker.Service.Domain.Location;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.GetLocation
{
    public class LoadLocationOutput
    {
        public Location Location { get; set; }

        public bool IsFromApi { get; set; }

    }
}