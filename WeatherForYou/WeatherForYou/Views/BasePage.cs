using System;
using System.Collections.Generic;
using System.Text;
using WeatherForYou.ViewModel;
using Xamarin.Forms;

namespace WeatherForYou.Views
{
    public class BasePage : ContentPage
    {
        private bool initialLoad;
        protected BasePageViewModel ViewModel;

        public BasePage()
        {
            initialLoad = true;
        }

        public void SetViewModel<T>(object initialData = null) where T : BasePageViewModel
        {
            try
            {
                BindingContext = ViewModel = DependencyLocator.Resolve<T>(initialData);
            }
            catch(Exception e)
            { }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel?.OnNavigatedTo(initialLoad);
            initialLoad = false;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel?.OnNavigatedAway();
        }
    }
}
