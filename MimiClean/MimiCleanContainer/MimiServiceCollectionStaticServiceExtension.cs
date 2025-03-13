using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// 全ての登録機能は、IServiceCollection.(Try)Add~~を利用しているので、IServiceProvider.GetServiceに対応している
    /// </summary>
    internal static class MimiServiceCollectionStaticServiceExtension
    {
        public static void AddStatic<TInterface, TInstance>(this IServiceCollection @this, Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            var staticFactory = StaticFactory<TInterface, TInstance>(factory);
            @this.AddSingleton<TInterface, TInstance>(staticFactory);
        }

        public static void AddStatic<TInterface>(this IServiceCollection @this, Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            @this.AddStatic<TInterface, TInterface>(factory);
        }

        public static void TryAddStatic<TInterface, TInstance>(this IServiceCollection @this, Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            if (@this.AllNot<TInterface>())
            {
                @this.AddStatic<TInterface, TInstance>(factory);
            }
        }

        public static void TryAddStatic<TInterface>(this IServiceCollection @this, Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            if (@this.AllNot<TInterface>())
            {
                @this.AddStatic(factory);
            }
        }

        private static Func<IServiceProvider, TInstance> StaticFactory<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            return serviceProvider => StaticFactory<TInterface, TInstance>(factory, serviceProvider);
        }

        private static TInstance StaticFactory<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory, IServiceProvider serviceProvider)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            TInstance instance;
            if (MimiServiceStatic<TInstance>.IsUsed)
            {
                instance = MimiServiceStatic<TInstance>.Instance;
                MimiServiceStatic<TInterface>.Instance = instance;

                return instance;
            }
            else
            {
                instance = CreateInstance<TInterface, TInstance>(factory, serviceProvider);
                MimiServiceStatic<TInterface>.Instance = instance;

                //if TInterface is TInstance, it become to false.
                if (!MimiServiceStatic<TInstance>.IsUsed)
                {
                    MimiServiceStatic<TInstance>.Instance = instance;
                }

                return instance;
            }
        }

        private static TInstance CreateInstance<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory, IServiceProvider serviceProvider)
            where TInterface : class
            where TInstance : class, TInterface
        {
            var instance = factory?.Invoke(serviceProvider);
            if (instance != null) return instance;

            instance = ActivatorUtilities.CreateInstance<TInstance>(serviceProvider);
            return instance ?? throw new InvalidOperationException($"Can't create instance of the type {typeof(TInstance).Name}.");
        }
    }
}
