using System;


namespace StudioIdGames.MimiClean.CleanContainer
{
    public static class MimiServiceDefault<TInterface>
            where TInterface : class, IMimiService
    {
        internal static int Priority { get; set; }

        internal static Func<IServiceProvider, TInterface> Factory { get; set; }

        internal static bool TryGetFactory(out Func<IServiceProvider, TInterface> factory)
        {
            factory = Factory;
            return factory != null;
        }

        public static void SetDefult(Func<IServiceProvider, TInterface> factory, int priority)
        {
            if (Priority <= priority)
            {
                Priority = priority;
                Factory = factory;
            }
        }
    }
}
