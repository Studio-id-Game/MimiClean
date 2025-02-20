using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiClean.CleanContainer
{
    public class MimiServiceContainer
    {
        private readonly MimiServiceCollection services;

        public MimiServiceContainer()
        {
            services = new MimiServiceCollection();
            services.AddTransient<MimiServiceProvider>();
        }

        public MimiServiceContainer Add<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            services.AddService<TInterface, TInstance>(factory);
            return this;
        }

        public MimiServiceContainer Add<TInterface>(Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            services.AddService(factory);
            return this;
        }

        public MimiServiceProvider BuildServiceProvider()
        {
            return new MimiServiceProvider(services.BuildServiceProvider());
        }
    }
}
