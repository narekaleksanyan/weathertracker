namespace ZeroApp.ForecastTracker.Service.Domain.Location
{
    public class Location
    {
        public Location()
        {
        }

        public Location(string name, double longitude, double latitude, Forecast forecast)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
            Forecast = forecast;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public double Longitude { get; private set; }

        public double Latitude { get; private set; }

        public Forecast Forecast { get; private set; }

        public static Location Load(int id, string name, double longitude, double latitude, Forecast forecast)
        {
            var location = new Location
                {Id = id, Name = name, Longitude = longitude, Latitude = latitude, Forecast = forecast};
            return location;
        }
    }
}
