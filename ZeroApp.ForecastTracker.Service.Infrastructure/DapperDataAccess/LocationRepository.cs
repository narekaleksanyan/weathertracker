using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ZeroApp.ForecastTracker.Service.Application.Repositories;
using ZeroApp.ForecastTracker.Service.Domain.Location;
using ZeroApp.ForecastTracker.Service.Infrastructure.Exceptions;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.DapperDataAccess
{
    public class LocationRepository : DapperBaseRepository, ILocationRepository
    {
        public LocationRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<Location>> GetAllLocations()
        {
            using (var connection = CreateNewConnection())
            {
                var query = await connection.QueryAsync<Entities.Location>("GetAllLocations");
                return query.Select(x => Location.Load(x.Id, x.Name, x.Longitude, x.Latitude)).ToList();
            }
        }

        public async Task<Location> GetLocationByName(string name, bool throwException = false)
        {
            using (var connection = CreateNewConnection())
            {
                var @params = new DynamicParameters();
                @params.Add("@Name", name);
                var query = await connection.QueryAsync<Entities.Location>("GetLocationByName", @params);
                var location = query.Select(x => Location.Load(x.Id, x.Name, x.Longitude, x.Latitude)).FirstOrDefault();
                if (throwException && location == null)
                {
                    throw new EntityNotFoundException("Name", name);
                }

                return location;
            }
        }

        public Task SaveLocation(string name, decimal longitude, decimal latitude)
        {
            throw new System.NotImplementedException();
        }
    }
}
