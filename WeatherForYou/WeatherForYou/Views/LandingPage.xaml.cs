using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForYou.Model;
using WeatherForYou.ViewModel;
using WeatherForYou.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherForYou
{
    public partial class LandingPage : BasePage
    {
        public LandingPage()
        {
            InitializeComponent();
            SetViewModel<LandingPageViewModel>();
        }

        public void OnDateSeleted(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var day = (e.SelectedItem as DateList);
                (ViewModel as LandingPageViewModel)?.NavigateToHomePage(day);

                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}