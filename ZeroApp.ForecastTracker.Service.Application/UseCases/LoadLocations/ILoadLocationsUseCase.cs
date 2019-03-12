using System.Collections.Generic;
using System.Threading.Tasks;
using ZeroApp.ForecastTracker.Service.Domain.Location;

namespace ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocations
{
    public interface ILoadLocationsUseCase
    {
        Task<List<Location>> Execute();
    }
}