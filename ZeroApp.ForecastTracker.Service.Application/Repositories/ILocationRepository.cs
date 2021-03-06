﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Domain.Location;

namespace ZeroApp.ForecastTracker.Service.Application.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocationByName(string name,bool throwException = false);
        Task<int> SaveLocation(string name, double longitude, double latitude);
        Task<Location> GetLocationById(int id, bool throwException = false);
    }
}