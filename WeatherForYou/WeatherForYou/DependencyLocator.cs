using Autofac;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WeatherForYou.Service;
using WeatherForYou.ViewModel;

namespace WeatherForYou
{
    public static class DependencyLocator
    {
        static readonly IContainer container;

        static DependencyLocator()
        {
            var builder = new ContainerBuilder();

            RegisterViewModels(builder);
            RegisterServices(builder);

            container = builder.Build();
        }

        static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<LandingPageViewModel>();

        }

        static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<HttpClient>().SingleInstance();
            builder.RegisterType<WeatherForcastService>().As<IWeatherForcastService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
        }

        public static ServiceType Resolve<ServiceType>(object initialData = null) where ServiceType : class
        {
            return container.Resolve<ServiceType>(new NamedParameter("initialData", initialData));
        }
    }
}
