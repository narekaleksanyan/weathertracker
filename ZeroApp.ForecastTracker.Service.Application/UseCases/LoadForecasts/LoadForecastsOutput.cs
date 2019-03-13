using System.Collections.Generic;
using ZeroApp.ForecastTracker.Service.Domain.Location;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadForecasts
{
    public class LoadForecastsOutput
    {
        public List<Location> Forecasts { get; set; }
    }
}