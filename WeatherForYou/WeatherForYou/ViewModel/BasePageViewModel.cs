using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForYou.HelperClass;

namespace WeatherForYou.ViewModel
{
    public class BasePageViewModel : NotifyPropertyChangedHelper
    {
        /// <summary>
        /// One operations for page (ex. load data)
        /// </summary>
        public virtual void LoadData() { }

        /// <summary>
        /// Operations to perform each time page appears (ex. listen to readings)
        /// </summary>
        public virtual void RegisterForEvents() { }

        /// <summary>
        /// Clean up listeners
        /// </summary>
        public virtual void CleanupEvents() { }

        public virtual void RefreshData() { }

        protected bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            protected set { SetProperty(ref isLoading, value); }
        }
                
        public void OnNavigatedTo(bool initialLoad)
        {
            Task.Run(() => RegisterForEvents());

            if (initialLoad)
            {
                Task.Run(() => LoadData());
            }
            else
            {
                Task.Run(() => RefreshData());
            }
        }

        public void OnNavigatedAway()
        {
            Task.Run(() => CleanupEvents());
        }        
    }
}
