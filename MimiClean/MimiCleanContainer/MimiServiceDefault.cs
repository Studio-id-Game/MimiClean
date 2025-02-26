using Microsoft.Extensions.DependencyInjection;
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

        public static void Set(MimiServiceContainer container, Func<IServiceProvider, TInterface> factory, int priority = 0)
        {
            if (Priority <= priority)
            {
                Priority = priority;
                Factory = factory;
                container.Add(factory);
            }
        }

        public static void Set<TInstance>(MimiServiceContainer container, int priority = 0)
            where TInstance : class, TInterface
        {
            if (Priority <= priority)
            {
                Priority = priority;

                Func<IServiceProvider, TInstance> factory = SetFactory<TInstance>;
                Factory = factory;
                container.Add<TInterface, TInstance>(factory);
            }
        }

        public static void Ref<TRefTo>(MimiServiceContainer container, int priority = 0)
            where TRefTo : class, TInterface
        {
            if (Priority <= priority)
            {
                Priority = priority;

                Func<IServiceProvider, TRefTo> factory = RefFactory<TRefTo>;
                Factory = factory;
                container.Add<TInterface, TRefTo>(factory);
            }
        }

        public static TRefTo RefFactory<TRefTo>(IServiceProvider serviceProvider)
            where TRefTo : class, TInterface
        {
            return serviceProvider.GetMimiService<TRefTo>();
        }

        public static TInstance SetFactory<TInstance>(IServiceProvider serviceProvider)
        {
            return ActivatorUtilities.CreateInstance<TInstance>(serviceProvider);
        }
    }
}
