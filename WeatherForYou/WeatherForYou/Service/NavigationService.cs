using System;
using System.Collections.Generic;
using System.Text;
using WeatherForYou.Views;
using Xamarin.Forms;

namespace WeatherForYou.Service
{
    public interface INavigationService
    {
        void Navigate<T>(object initialData = null) where T : BasePage;
        void NavigateAndPop<T>(object initialData = null) where T : BasePage;
        void OpenModal<T>(object initialData = null) where T : BasePage;
        void SetMainPage<T>(object initialData = null) where T : BasePage;
        void NavigatePop();
        void RemoveParentPage();
        Page GetParentPage();
        Page GetCurrentPage();
        
    }

    public class NavigationService : INavigationService
    {        
        public void OpenModal<T>(object initialData = null) where T : BasePage
        {
            Device.BeginInvokeOnMainThread(() =>
                Application.Current.MainPage.Navigation.PushModalAsync(CreatePage<T>(initialData)));
        }

        public void Navigate<T>(object initialData = null) where T : BasePage
        {
            Device.BeginInvokeOnMainThread(() =>
                Application.Current.MainPage.Navigation.PushAsync(CreatePage<T>(initialData)));
        }

        public void NavigateAndPop<T>(object initialData = null) where T : BasePage
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = new NavigationPage(CreatePage<T>(initialData));
            });
        }

        public void NavigatePop()
        {
            Device.BeginInvokeOnMainThread(() => Application.Current.MainPage.Navigation.PopAsync());
        }

        public Page GetParentPage()
        {
            var parentCount = Application.Current.MainPage.Navigation.NavigationStack.Count > 1 ?
                Application.Current.MainPage.Navigation.NavigationStack.Count - 2 : 0;
            return Application.Current.MainPage.Navigation.NavigationStack[parentCount];
        }

        public Page GetCurrentPage()
        {
            var currentCount = Application.Current.MainPage.Navigation.NavigationStack.Count > 1 ?
                Application.Current.MainPage.Navigation.NavigationStack.Count - 1 : 0;
            return Application.Current.MainPage.Navigation.NavigationStack[currentCount];
        }

        public void RemoveParentPage()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var count = Application.Current.MainPage.Navigation.NavigationStack.Count;
                var page = Application.Current.MainPage.Navigation.NavigationStack[count - 2];
                Application.Current.MainPage.Navigation.RemovePage(page);
            });
        }

        private BasePage CreatePage<T>(object initialData) where T : BasePage
        {
            return (initialData != null ?
                        Activator.CreateInstance(typeof(T), new object[] { initialData }) :
                        Activator.CreateInstance(typeof(T))) as BasePage;
        }
     
        public void SetMainPage<T>(object initialData = null) where T : BasePage
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = CreatePage<T>(initialData);
            });
        }

    }
}
