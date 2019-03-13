using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using ZeroApp.ForecastTracker.Client.Commands;
using ZeroApp.ForecastTracker.Client.Services;
using ZeroApp.ForecastTracker.Service.Contracts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadForecasts;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocation;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Contracts.SaveLocation;

namespace ZeroApp.ForecastTracker.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IForeCastService _foreCastService;

        public MainViewModel()
        {
            _foreCastService = new ForecastServiceClient();
            LocationsForecasts = new ObservableCollection<ForecastItem>();
            var timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(30)};
            timer.Tick += Timer_Tick; ;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadForecasts();
        }

        public string PlaceName { get; set; }

        public ObservableCollection<ForecastItem> LocationsForecasts { get; set; }

        private async void LoadForecasts()
        {
            var response = await _foreCastService.LoadForecastsAsync(new LoadForecastsRequest());
            LocationsForecasts = new ObservableCollection<ForecastItem>(response.ForecastItems);
        }

        private async Task<int> LoadLocation()
        {
            int locationId;
            var response = await _foreCastService.LoadLocationAsync(new LoadLocationRequest {Name = PlaceName});
            if (!response.Id.HasValue)
            {
                var saveResponse = await _foreCastService.SaveLocationAsync(new SaveLocationRequest
                    {Latitude = response.Latitude, Longitude = response.Latitude, Name = response.Name});
                locationId = saveResponse.LocationId;
            }
            else
            {
                locationId = response.Id.Value;
            }

            return locationId;
        }

        private async void LoadLocationForecast()
        {
            var locationId = await LoadLocation();
            var response = await _foreCastService.LoadLocationForecastAsync(new LoadLocationForecastRequest
                {LocationId = locationId});
            LocationsForecasts.Add(new ForecastItem
            {
                Longitude = response.Longitude, Latitude = response.Latitude, Name = response.Name,
                Wind = response.Wind, Humidity = response.Humidity, LocationId = response.Id
            });
        }

        private ICommand _enterCommand;
        public ICommand EnterCommand
        {
            get => _enterCommand ?? (_enterCommand = new EnterCommand(LoadLocationForecast));
            set => _enterCommand = value;
        }
    }
}
