using System;

namespace StudioIdGames.MimiCleanContainer
{
    public class MimiServiceProvider : IServiceProvider
    {
        public IServiceProvider BaseProvider { get; }

        public MimiServiceProvider(IServiceProvider baseProvider)
        {
            BaseProvider = baseProvider;
        }

        public T GetService<T>()
            where T : class, IMimiService
        {
            return BaseProvider.GetMimiService<T>();
        }

        public MimiServiceProvider Config<T>(Action<T> config)
            where T : class, IMimiService
        {
            config?.Invoke(BaseProvider.GetMimiService<T>());
            return this;
        }

        public object GetService(Type serviceType)
        {
            return BaseProvider.GetService(serviceType);
        }
    }
}
