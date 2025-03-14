using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// 全ての登録機能は、IServiceCollection.(Try)Add~~を利用しているので、IServiceProvider.GetServiceに対応している
    /// </summary>
    internal static class MimiServiceCollectionServiceExtension
    {
        public static void AddService<TInterface, TInstance>(this IServiceCollection @this, Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            var type = MimiServiceTypeAttributeCache.Get<TInstance>();
            if (type == MimiServiceType.None)
            {
                throw new InvalidOperationException($"Please add {nameof(MimiServiceTypeAttribute)} to {typeof(TInstance).Name}");
            }

            if (factory == null)
            {
                AddServiceWithoutFactory<TInterface, TInstance>(@this, type);
                return;
            }
            else
            {
                AddServiceWithFactory<TInterface, TInstance>(@this, type, factory);
            }
        }

        public static void AddService<TInterface>(this IServiceCollection @this, Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            @this.AddService<TInterface, TInterface>(factory);
        }

        public static void TryAddService<TInterface, TInstance>(this IServiceCollection @this, Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            if (@this.AllNot<TInterface>())
            {
                @this.AddService<TInterface, TInstance>(factory);
            }
        }

        public static void TryAddService<TInterface>(this IServiceCollection @this, Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            if (@this.AllNot<TInterface>())
            {
                @this.AddService(factory);
            }
        }

        private static void AddServiceWithoutFactory<TInterface, TInstance>(IServiceCollection @this, MimiServiceType serviceType)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            switch (serviceType)
            {
                case MimiServiceType.Singleton:
                    @this.AddSingleton<TInterface, TInstance>();
                    return;

                case MimiServiceType.Scoped:
                    @this.AddScoped<TInterface, TInstance>();
                    return;

                case MimiServiceType.Transient:
                    @this.AddTransient<TInterface, TInstance>();
                    return;

                case MimiServiceType.Static:
                    @this.AddStatic<TInterface, TInstance>();
                    return;

                default:
                    throw new InvalidOperationException(nameof(MimiServiceTypeAttribute.ServiceType));
            }
        }

        private static void AddServiceWithFactory<TInterface, TInstance>(IServiceCollection @this, MimiServiceType serviceType, Func<IServiceProvider, TInstance> factory)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            switch (serviceType)
            {
                case MimiServiceType.Singleton:
                    @this.AddSingleton<TInterface, TInstance>(factory);
                    return;

                case MimiServiceType.Scoped:
                    @this.AddScoped<TInterface, TInstance>(factory);
                    return;

                case MimiServiceType.Transient:
                    @this.AddTransient<TInterface, TInstance>(factory);
                    return;

                case MimiServiceType.Static:
                    @this.AddStatic<TInterface, TInstance>(factory);
                    return;

                default:
                    throw new InvalidOperationException(nameof(MimiServiceTypeAttribute.ServiceType));
            }
        }
    }
}
