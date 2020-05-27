using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForYou.Model;

namespace WeatherForYou.Service
{
    public interface IWeatherForcastService
    {
        Task<WeatherResponse> GetWeatherResponseAsync(string cityName);
        WeatherResponse GetLastCityWeather();
    }
    public class WeatherForcastService : IWeatherForcastService
    {
        readonly HttpClient client;
        string uri = "https://samples.openweathermap.org/data/2.5/forecast?q=";
        public WeatherResponse WeatherResponse { get; private set; } = new WeatherResponse();
        public string CityName { get; set; }
        public WeatherForcastService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<WeatherResponse> GetWeatherResponseAsync(string cityName)
        {
            CityName = cityName;
            
            uri = $"{uri}{cityName}&appid=439d4b804bc8187953eb36d2a8c26a02";

            try
            {
                var result = await client.GetAsync(uri);
                WeatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(result.Content.ReadAsStringAsync().Result);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : {0} while fetching the data.", ex.Message);
            }
            return WeatherResponse;
        }

        public WeatherResponse GetLastCityWeather()
        {
            return WeatherResponse;
        }
    }
}
