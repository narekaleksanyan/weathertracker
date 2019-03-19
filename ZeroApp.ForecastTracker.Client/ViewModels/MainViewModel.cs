using System;
using System.Collections.ObjectModel;
using System.Windows;
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
         //   timer.Start();
             UpdateDataGrid();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           UpdateDataGrid();
        }

        private string _placeName;

        public string PlaceName
        {
            get => _placeName;
            set
            {
                _placeName = value;
                OnPropertyChanged(this, "PlaceName");
            }
        }

        public ObservableCollection<ForecastItem> LocationsForecasts { get; set; }
        
        private async void AddNewForecast()
        {
            var locationResponse = await _foreCastService.LoadLocationAsync(new LoadLocationRequest { Name = PlaceName });
            if (locationResponse.Id.HasValue)
            {
                MessageBox.Show("Location already exists");
                PlaceName = null;
            }
            else
            {
                if (locationResponse.StatusCode == 404)
                {
                    MessageBox.Show("This location does not exist on the glob");
                    PlaceName = null;
                    return;
                }

                var saveResponse = await _foreCastService.SaveLocationAsync(new SaveLocationRequest
                {
                    Latitude = locationResponse.Latitude,
                    Longitude = locationResponse.Longitude,
                    Name = locationResponse.Name
                });

                var response = await _foreCastService.LoadLocationForecastAsync(new LoadLocationForecastRequest
                    {LocationId = saveResponse.LocationId});
                LocationsForecasts.Add(new ForecastItem
                {
                    Longitude = response.Longitude,
                    Latitude = response.Latitude,
                    Name = response.Name,
                    Wind = response.Wind,
                    Humidity = response.Humidity,
                    LocationId = response.Id,
                    Time = response.Time,
                    Summary = response.Summary,
                    Temperature = response.Temperature,
                    Timezone = response.Timezone
                });
                PlaceName = null;
            }
        }

        private async void UpdateDataGrid()
        {
            var response = await _foreCastService.LoadForecastsAsync(new LoadForecastsRequest());
            LocationsForecasts.Clear();
            foreach (var item in response.ForecastItems)
            {
                LocationsForecasts.Add(item);
            }
        }

        private ICommand _enterCommand;
        public ICommand EnterCommand
        {
            get => _enterCommand ?? (_enterCommand = new EnterCommand(AddNewForecast));
            set => _enterCommand = value;
        }
    }
}
