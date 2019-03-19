using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Application.Repositories;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.SaveLocation
{
    public class SaveLocationUseCase : ISaveLocationUseCase
    {
        private readonly ILocationRepository _locationRepository;
        public SaveLocationUseCase(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<int> Execute(string name, double longitude, double latitude)
        {
           var id = await _locationRepository.SaveLocation(name, longitude, latitude);
           return id;
        }
    }
}