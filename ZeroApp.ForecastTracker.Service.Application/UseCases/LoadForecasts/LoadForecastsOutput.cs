using System.Collections.Generic;
using ZeroApp.ForecastTracker.Service.Domain.Forecast;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadForecasts
{
    public class LoadForecastsOutput
    {
        public List<Forecast> Forecasts { get; set; }
    }
}