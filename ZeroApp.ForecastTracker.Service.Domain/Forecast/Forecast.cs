namespace ZeroApp.ForecastTracker.Service.Domain.Forecast
{
    public class Forecast
    {
        public Location.Location Location { get; private set; }

        public  string Wind { get; private set; }

        public  string Humidity { get; private set; }

        public static Forecast Load(string wind, string humidity, Location.Location location)
        {
            var forecast = new Forecast {Wind = wind, Humidity = humidity, Location = location};
            return forecast;
        }
    }
}
