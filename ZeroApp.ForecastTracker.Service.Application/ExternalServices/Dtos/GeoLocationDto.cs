namespace ZeroApp.ForecastTracker.Service.Application.ExternalServices.Dtos
{
    public class GeoLocationDto
    {
        public int StatusCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class ForecastDto
    {
        public int StatusCode { get; set; }

        public float Wind { get; set; }

        public float Humidity { get; set; }

        public  float Temperature { get; set; }
 
        public int Id { get; set; }

        public string Name { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public  string Timezone { get; set; }

        public long Time { get; set; }

        public  string Summary { get; set; }
    }
}
