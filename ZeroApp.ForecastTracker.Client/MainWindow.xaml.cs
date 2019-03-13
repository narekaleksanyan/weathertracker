using System.Windows;
using ZeroApp.ForecastTracker.Client.Services;
using ZeroApp.ForecastTracker.Service.Contracts.LoadLocationForecast;

namespace ZeroApp.ForecastTracker.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test();
        }

        private async void Test()
        {
            ForecastServiceClient client = new ForecastServiceClient();
            var reponse =await client.LoadLocationForecastAsync(new LoadLocationForecastRequest());
        }
    }
}
