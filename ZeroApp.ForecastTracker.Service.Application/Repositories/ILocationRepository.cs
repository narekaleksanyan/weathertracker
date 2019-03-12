using System.Collections.Generic;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Domain.Location;

namespace ZeroApp.ForecastTracker.Service.Application.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocationByName(string name,bool throwException = false);
        Task SaveLocation(string name, decimal longitude, decimal latitude);
    }
}