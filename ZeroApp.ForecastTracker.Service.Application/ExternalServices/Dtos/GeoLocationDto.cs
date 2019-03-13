namespace ZeroApp.ForecastTracker.Service.Application.ExternalServices.Dtos
{
    public class GeoLocationDto
    {

    }

    public class ForecastDto
    {
        public string Wind { get; set; }

        public string Humidity { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
