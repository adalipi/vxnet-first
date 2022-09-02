﻿using Microsoft.Extensions.Configuration;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vxnet_1.Services;
using vxnet_1.RestService;

namespace vxnet_1
{
    public static class MauiServiceRegistrator
    {
        public static void RegisterDependecies(this IServiceCollection services)
        {
            Pages(services);
            ViewModels(services);
            Services(services);
            HttpClients(services);
        }

        static void Pages(IServiceCollection services)
        {
            services.AddSingleton<MainPage>(); //each time the same page will be created, will not change
            services.AddTransient<DetailsPage>(); // every time new page will be created since details will change based on id
        }

        static void ViewModels(IServiceCollection services)
        {
            services.AddSingleton<ShopListViewModel>(); //each time the same page will be created, will not change
            services.AddTransient<ShopDetailsViewModel>();// every time new page will be created since details will change based on id
        }

        static void Services(IServiceCollection services)
        {
            services.AddSingleton(Connectivity.Current);
            services.AddSingleton(Geolocation.Default);
            services.AddSingleton(Map.Default);

            services.AddSingleton<ShopService>();
            services.AddSingleton<RegAppService>();
        }

        static void HttpClients(IServiceCollection services)
        {
            services.AddSingleton<IApiService, ApiService>();
        }
    }
}
