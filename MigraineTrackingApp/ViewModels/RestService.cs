/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 18/4/2022
 */

using MigraineTrackingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MigraineTrackingApp.ViewModels
{
    /// <summary>
    /// accesses openweather API through http request
    /// </summary>
    public class RestService
    {
        HttpClient _client;

       /// <summary>
       /// create instance of http client
       /// </summary>
        public RestService()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// query gets back response deserialise JSON response and stores in models
        /// </summary>
        /// <param name="query">contains open weather API and location</param>
        /// <returns></returns>
        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return weatherData;
        }
    }
}
