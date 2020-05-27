using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForYou.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherForYou.Views
{
    public partial class Home : BasePage
    {
        public Home(WeatherList weather)
        {
            InitializeComponent();

        }
    }
}