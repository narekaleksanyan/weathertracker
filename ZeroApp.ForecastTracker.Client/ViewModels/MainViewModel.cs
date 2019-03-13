using ZeroApp.ForecastTracker.Client.Services;
using ZeroApp.ForecastTracker.Service.Contracts;

namespace ZeroApp.ForecastTracker.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IForeCastService _foreCastService;

        public MainViewModel()
        {
            _foreCastService = new ForecastServiceClient();
        }
    }
}
