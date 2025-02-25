using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiCleanContainer
{
    public static class MimiServiceProviderExtension
    {
        public static T GetMimiService<T>(this IServiceProvider serviceProvider)
            where T : class, IMimiService
        {
            return StaticServices<T>.IsUsed ? StaticServices<T>.Instance : serviceProvider.GetService<T>();
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
