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

        public object GetService(Type serviceType)
        {
            return BaseProvider.GetService(serviceType);
        }
    }
}
