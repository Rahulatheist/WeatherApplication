using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherForYou.Model;
using WeatherForYou.Service;
using WeatherForYou.Views;
using Xamarin.Forms;

namespace WeatherForYou.ViewModel
{
    public class LandingPageViewModel : BasePageViewModel
    {
        private ObservableCollection<DateList> dates;
        public ObservableCollection<DateList> Dates
        {
            get { return dates; }
            set { SetProperty(ref dates, value); }
        }

        private List<WeatherList> completeWeatherList;
        public List<WeatherList> CompleteWeatherList
        {
            get { return completeWeatherList; }
            set { SetProperty(ref completeWeatherList, value); }
        }

        private string cityNameValue;
        public string CityNameValue
        {
            get { return cityNameValue; }
            set
            {
                SetProperty(ref cityNameValue, value);
            }
        }

        public string Lat { get; set; }
        public string Long { get; set; }
        public string Country { get; set; }

        ICommand searchWeatherCommand;
        public ICommand SearchWeatherCommand
        {
            get { return searchWeatherCommand; }
            private set { SetProperty(ref searchWeatherCommand, value); }
        }

        IWeatherForcastService weatherForcastService;
        INavigationService navigationService;
        string cityName;

        public LandingPageViewModel(IWeatherForcastService weatherForcastService, INavigationService navigationService)
        {
            this.weatherForcastService = weatherForcastService;
            this.navigationService = navigationService;

            searchWeatherCommand = new Command(OnSearchClickedAsync);
        }

        public override void LoadData()
        {
            base.LoadData();
        }
        public override void RefreshData()
        {
            IsLoading = true;
            Initialization(weatherForcastService.GetLastCityWeather());
            IsLoading = false;
        }
        public void NavigateToHomePage(DateList date)
        {
            navigationService.Navigate<Home>(CompleteWeatherList.Where(w => w.dt_txt.Equals(date.Date_Time)));
        }
        private async void OnSearchClickedAsync(object obj)
        {
            IsLoading = true;
            var result = await weatherForcastService.GetWeatherResponseAsync(CityNameValue);

            if (result != null)
            {
                Initialization(result);

            }
            else
                DisplayAlert("Error", "Data is not available", "Ok", () =>
                   {
                       CityNameValue = string.Empty;
                   });

            IsLoading = false;
        }

        private void Initialization(WeatherResponse result)
        {
            CompleteWeatherList = result.list.ToList();
            Lat = result.city.coord.lat.ToString();
            Long = result.city.coord.lon.ToString();
            Country = result.city.country;
            foreach (var item in CompleteWeatherList)
            {
                Dates.Add(new DateList() { Date_Time = item.dt_txt });
            }
        }

        private void DisplayAlert(string title, string message, string cancel, Action onClose = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(title, message, cancel);

                if (onClose != null)
                {
                    await Task.Run(onClose);
                }
            });
        }


    }
}
