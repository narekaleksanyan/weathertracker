﻿using Autofac;
using Autofac.Integration.Wcf;
using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using ZeroApp.ForecastTracker.Service.Application;
using ZeroApp.ForecastTracker.Service.Application.ExternalServices;
using ZeroApp.ForecastTracker.Service.Application.Repositories;
using ZeroApp.ForecastTracker.Service.Application.UseCases;
using ZeroApp.ForecastTracker.Service.Application.UseCases.GetLocation;
using ZeroApp.ForecastTracker.Service.Application.UseCases.LoadForecasts;
using ZeroApp.ForecastTracker.Service.Application.UseCases.LoadLocationForecast;
using ZeroApp.ForecastTracker.Service.Application.UseCases.SaveLocation;
using ZeroApp.ForecastTracker.Service.Contracts;
using ZeroApp.ForecastTracker.Service.Infrastructure.DapperDataAccess;
using ZeroApp.ForecastTracker.Service.Infrastructure.ExternalService;
using ZeroApp.ForecastTracker.Service.Infrastructure.Settings;

namespace ZeroApp.ForecastTracker.Service.WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            using (var container = builder.Build())
            {
                var address = new Uri("http://localhost:8080/ForecastService");
                var host = new ServiceHost(typeof(ForecastService), address);

                var basicHttpBinding = new BasicHttpBinding();
                host.AddServiceEndpoint(typeof(IForeCastService), basicHttpBinding, string.Empty);

                host.AddDependencyInjectionBehavior<ForecastService>(container);

                host.Description.Behaviors.Add(
                    new ServiceMetadataBehavior {HttpGetEnabled = true, HttpGetUrl = address});

                host.Description.Behaviors.Remove(
                    typeof(ServiceDebugBehavior));
                host.Description.Behaviors.Add(
                    new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });

                host.Open();

                Console.WriteLine("The host has been opened.");
                Console.ReadLine();

                host.Close();
                Environment.Exit(0);
            }
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.Register(c =>
                    new LocationRepository(
                        ConfigurationManager.ConnectionStrings["ForecastDb"].ConnectionString))
                .As<ILocationRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ExternalForecastServiceSettings>().As<IForecastServiceSettings>().AsSelf();
            builder.RegisterType<GeoLocationServiceSettings>().As<IGeoLocationServiceSettings>().AsSelf();

            builder.RegisterType<GeoLocationService>().As<IGeoLocationService>();
            builder.RegisterType<ExternalForecastService>().As<IExternalForecastService>();

            builder.RegisterType<LoadLocationForecastUseCase>().As<ILoadLocationForecastUseCase>();
            builder.RegisterType<LoadLocationUseCase>().As<ILoadLocationUseCase>();
            builder.RegisterType<SaveLocationUseCase>().As<ISaveLocationUseCase>();
            builder.RegisterType<LoadForecastsUseCase>().As<ILoadForecastsUseCase>();

            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();
            builder.RegisterType<ForecastService>();
        }
    }
}
