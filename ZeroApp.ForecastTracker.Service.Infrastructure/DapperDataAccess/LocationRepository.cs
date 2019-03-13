using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                return query.Select(x => Location.Load(x.Id, x.Name, x.Longitude, x.Latitude,null)).ToList();
            }
        }

        public async Task<Location> GetLocationByName(string name, bool throwException = false)
        {
            using (var connection = CreateNewConnection())
            {
                var @params = new DynamicParameters();
                @params.Add("@Name", name);
                var query = await connection.QueryAsync<Entities.Location>("GetLocationByName", @params);
                var location = query.Select(x => Location.Load(x.Id, x.Name, x.Longitude, x.Latitude,null)).FirstOrDefault();
                if (throwException && location == null)
                {
                    throw new EntityNotFoundException("Name", name);
                }

                return location;
            }
        }

        public async Task SaveLocation(string name, decimal longitude, decimal latitude)
        {
            using (var connection = CreateNewConnection())
            {
                var @params = new DynamicParameters();
                @params.Add("@name", name);
                @params.Add("@longitude", longitude);
                @params.Add("@latitude", latitude);
                await connection.ExecuteAsync("SaveLocation", @params);
            }
        }

        public async Task<Location> GetLocationById(int id, bool throwException = false)
        {
            using (var connection = CreateNewConnection())
            {
                var @params = new DynamicParameters();
                @params.Add("@id", id);
                var query = await connection.QueryAsync<Entities.Location>("GetLocationById", @params);
                var location = query.Select(x => Location.Load(x.Id, x.Name, x.Longitude, x.Latitude,null)).FirstOrDefault();
                if (throwException && location == null)
                {
                    throw new EntityNotFoundException("Id", id.ToString());
                }

                return location;
            }
        }
    }
}
