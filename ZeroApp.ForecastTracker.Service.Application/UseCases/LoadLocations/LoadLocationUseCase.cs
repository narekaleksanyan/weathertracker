using System.Collections.Generic;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.Repositories;
using ZeroApp.ForecastTracker.Service.Domain.Location;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocations
{
    public class LoadLocationUseCase : ILoadLocationsUseCase
    {
        private readonly ILocationRepository _locationRepository;

        public LoadLocationUseCase(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<Location>> Execute()
        {
            return await _locationRepository.GetAllLocations();
        }
    }
}