namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocationForecast
{
    public class LoadLocationForecastOutput
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public float Wind { get; set; }
        public float Humidity { get; set; }
        public float Temperature { get; set; }
        public string Timezone { get; set; }
        public long Time { get; set; }
        public string Summary { get; set; }
    }
}