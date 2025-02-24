using System;


namespace StudioIdGames.MimiCleanContainer
{
    public static class MimiServiceDefault<TInterface>
            where TInterface : class, IMimiService
    {
        internal static int Priority { get; set; } = -1;

        internal static Func<IServiceProvider, TInterface> Factory { get; set; }

        internal static bool TryGetFactory(out Func<IServiceProvider, TInterface> factory)
        {
            factory = Factory;
            return factory != null;
        }

        public static void SetDefault(MimiServiceContainer container, Func<IServiceProvider, TInterface> factory, int priority = 0)
        {
            if (Priority <= priority)
            {
                Priority = priority;
                Factory = factory;
                container.Add(factory);
            }
        }

        public static void SetDefault<TInstance>(MimiServiceContainer container, int priority = 0)
            where TInstance : class, TInterface
        {
            if (Priority <= priority)
            {
                Priority = priority;
                container.Add<TInterface, TInstance>();
            }
        }
    }
}
