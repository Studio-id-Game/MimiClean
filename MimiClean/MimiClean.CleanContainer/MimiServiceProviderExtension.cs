﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiClean.CleanContainer
{
    public static class MimiServiceProviderExtension
    {
        public static T GetMimiService<T>(this IServiceProvider serviceProvider)
            where T : class, IMimiService
        {
            var serviceType = MimiServiceTypeAttributeCache.Get<T>();
            if (serviceType == MimiServiceType.Static)
            {
                return StaticServices<T>.Instance;
            }
            else
            {
                return (T)serviceProvider.GetService(typeof(T));
            }
        }

        public static MimiServiceProvider AsMimiServiceProvider(this IServiceProvider serviceProvider)
        {
            if (serviceProvider is MimiServiceProvider mimi)
            {
                return mimi;
            }
            else
            {
                return new MimiServiceProvider(serviceProvider);
            }
        }

        public static MimiServiceProvider MimiServiceProvider(this IServiceScope serviceScope)
        {
            return serviceScope.ServiceProvider.AsMimiServiceProvider();
        }
    }
}
