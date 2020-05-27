using System;
using System.Collections.Generic;
using System.Text;
using WeatherForYou.Model;

namespace WeatherForYou.ViewModel
{
    public class HomePageViewModel : BasePageViewModel
    {
        public WeatherList DateWiseWeatherList { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public string MainTemperature { get; set; }
        public string MainTemperatureMin { get; set; }
        public string MainTemperatureMax { get; set; }
        public string Pressure { get; set; }
        public string SeaLavel { get; set; }
        public string GroundLevel { get; set; }
        public string Humidity { get; set; }
        public string CloudAll { get; set; }
        public string WindSpeed { get; set; }
        public string WindDegree { get; set; }

        public HomePageViewModel(WeatherList weatherList)
        {
            DateWiseWeatherList = weatherList;
        }

        public override void LoadData() 
        {
            WeatherMain = DateWiseWeatherList.weather[0].main;
            WeatherDescription = DateWiseWeatherList.weather[0].description;
            MainTemperature = DateWiseWeatherList.main.temp.ToString();
            MainTemperatureMin= DateWiseWeatherList.main.temp_min.ToString();
            MainTemperatureMax= DateWiseWeatherList.main.temp_max.ToString();
            Pressure=DateWiseWeatherList.main.pressure.ToString();
            SeaLavel= DateWiseWeatherList.main.sea_level.ToString();
            GroundLevel= DateWiseWeatherList.main.grnd_level.ToString();
            Humidity= DateWiseWeatherList.main.humidity.ToString();
            CloudAll= DateWiseWeatherList.clouds.all.ToString();
            WindSpeed = DateWiseWeatherList.wind.speed.ToString();
            WindDegree= DateWiseWeatherList.wind.deg.ToString();
        }

        public override void RefreshData() 
        {
            if (DateWiseWeatherList != null)
            {
                WeatherMain = DateWiseWeatherList.weather[0].main;
                WeatherDescription = DateWiseWeatherList.weather[0].description;
                MainTemperature = DateWiseWeatherList.main.temp.ToString();
                MainTemperatureMin = DateWiseWeatherList.main.temp_min.ToString();
                MainTemperatureMax = DateWiseWeatherList.main.temp_max.ToString();
                Pressure = DateWiseWeatherList.main.pressure.ToString();
                SeaLavel = DateWiseWeatherList.main.sea_level.ToString();
                GroundLevel = DateWiseWeatherList.main.grnd_level.ToString();
                Humidity = DateWiseWeatherList.main.humidity.ToString();
                CloudAll = DateWiseWeatherList.clouds.all.ToString();
                WindSpeed = DateWiseWeatherList.wind.speed.ToString();
                WindDegree = DateWiseWeatherList.wind.deg.ToString();
            }
        }
    }
}
