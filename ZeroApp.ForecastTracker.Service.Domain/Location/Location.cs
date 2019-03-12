namespace ZeroApp.ForecastTracker.Service.Domain.Location
{
    public class Location
    {
        public Location()
        {
            
        }

        public Location(string name, decimal longitude, decimal latitude)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public decimal Longitude { get; private set; }

        public decimal Latitude { get; private set; }

        public static Location Load(int id, string name, decimal longitude, decimal latitude)
        {
            var location = new Location {Id = id, Name = name, Longitude = longitude, Latitude = latitude};
            return location;
        }
    }
}
