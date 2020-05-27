using System;
using System.Diagnostics;
using WeatherForYou.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherForYou
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();

                MainPage = new NavigationPage(new LandingPage());
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
