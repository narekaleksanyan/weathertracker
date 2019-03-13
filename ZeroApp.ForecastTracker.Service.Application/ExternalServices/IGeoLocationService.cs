using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices.Dtos;

namespace ZeroApp.ForecastTracker.Service.Application.ExternalServices
{
    public interface IGeoLocationService
    {
        Task<GeoLocationDto> GetGeoLocationByName(string name);
    }
}