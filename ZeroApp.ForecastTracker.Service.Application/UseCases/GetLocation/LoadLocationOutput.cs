namespace ZeroApp.ForecastTracker.Service.Application.UseCases.GetLocation
{
    public class LoadLocationOutput
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public  int StatusCode { get; set; }
    }
}