/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.Models;
using MigraineTrackingApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordWeather : ContentPage
    {
        RestService _restService;
        string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        string OpenWeatherMapAPIKey = "1cdddc65df6697af0fd14a9ccae9b7c1";
        RecordMigraneViewModel mVm;
        internal RecordWeather(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            mVm = migraneVM;
            if(migraneVM.Location != " " && migraneVM.Location != null)
            {
                Location.Text = migraneVM.Location;
            }
            if (migraneVM.Humidity != " " && migraneVM.Humidity != null)
            {
                Humidity.Text = migraneVM.Humidity;
            }
            if (migraneVM.Temperature != " " && migraneVM.Temperature != null)
            {
                Temperature.Text = migraneVM.Temperature;
            }
            _restService = new RestService();
        }
        async void OnGetWeatherButtonClicked(object sender, EventArgs e)

        // Reference : https://github.com/xamarin/xamarin-forms-samples/tree/main/Weather
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }

            else
            {
                await DisplayAlert("", "Please Enter A Valid Location", "OK");
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private async void recordButton_Clicked(object sender, EventArgs e)
        {
            mVm.Location = Location.Text;
            mVm.Humidity = Humidity.Text;
            mVm.Temperature = Temperature.Text;

            await Navigation.PopAsync();
        }
    }
}