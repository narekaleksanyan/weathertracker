namespace ZeroApp.ForecastTracker.Service.Domain.Location
{
    public class Forecast
    {
        public float Wind { get; set; }

        public float Humidity { get; set; }

        public float Temperature { get; set; }

        public string Timezone { get; set; }

        public long Time { get; set; }

        public string Summary { get; set; }
    }
}
