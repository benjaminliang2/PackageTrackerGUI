using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Package_Tracker
{
    public partial class MainPage : ContentPage
    {
        private const string ApiUrl = "https://localhost:7151/api/v0/package/lasvegas";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            try
            {
                WeatherResponse weatherData = await GetWeatherDataAsync(ApiUrl);

                cityNameLabel.Text = $"City: {weatherData.Name}";
                temperatureLabel.Text = $"Temperature: {weatherData.Main.Temp}°C";
            }
            catch (Exception ex)
            {
                resultLabel.Text = "An error occurred: " + ex.Message;
            }
        }

        private async Task<WeatherResponse> GetWeatherDataAsync(string apiUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetFromJsonAsync<WeatherResponse>(apiUrl);
            }
        }
    }

    public class WeatherResponse
    {
        public string Name { get; set; }
        public MainData Main { get; set; }
    }

    public class MainData
    {
        public double Temp { get; set; }
    }
}
