using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// 全ての登録機能は、IServiceCollection.(Try)Add~~を利用しているので、IServiceProvider.GetServiceに対応している
    /// </summary>
    internal static class MimiServiceCollectionExtension
    {
        public static void AddStatic<TInterface, TInstance>(this IServiceCollection @this, Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            TInstance Factory(IServiceProvider serviceProvider)
            {
                TInstance instance;

                if (MimiServiceStatic<TInstance>.IsUsed)
                {
                    instance = MimiServiceStatic<TInstance>.Instance;

                    MimiServiceStatic<TInterface>.Instance = instance;
                }
                else
                {
                    instance = factory?.Invoke(serviceProvider) ??
                            ActivatorUtilities.CreateInstance<TInstance>(serviceProvider) ??
                            throw new InvalidOperationException($"Can't create instance of the type {typeof(TInstance).Name}.");

                    MimiServiceStatic<TInterface>.Instance = instance;

                    //if TInterface is TInstance, it become to false.
                    if (!MimiServiceStatic<TInstance>.IsUsed)
                    {
                        MimiServiceStatic<TInstance>.Instance = instance;
                    }
                }

                return instance;
            }

            @this.AddSingleton<TInterface, TInstance>(Factory);
        }

        public static void AddStatic<TInterface>(this IServiceCollection @this, Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            @this.AddStatic<TInterface, TInterface>(factory);
        }

        public static void AddService<TInterface, TInstance>(this IServiceCollection @this, Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            var type = MimiServiceTypeAttributeCache.Get<TInstance>();
            if (type == MimiServiceType.None)
            {
                throw new InvalidOperationException($"Please add {nameof(MimiServiceTypeAttribute)} to {typeof(TInstance).Name}");
            }

            @this.AddService<TInterface, TInstance>(type, factory);
        }

        public static void AddService<TInterface>(this IServiceCollection @this, Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            @this.AddService<TInterface, TInterface>(factory);
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

        public static MimiServiceProvider BuildMimiServiceProvider(this IServiceCollection @this, bool clearDefaults = true)
        {
            MimiServiceDefault.AddDefaultService?.Invoke(@this);

            if (clearDefaults)
            {
                MimiServiceDefault.AddDefaultService = null;
            }

            return new MimiServiceProvider(@this.BuildServiceProvider());
        }

        private static void AddService<TInterface, TInstance>(this IServiceCollection @this, MimiServiceType serviceType, Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            if (factory == null)
            {
                switch (serviceType)
                {
                    case MimiServiceType.Singleton:
                        @this.AddSingleton<TInterface, TInstance>();
                        break;

                    case MimiServiceType.Scoped:
                        @this.AddScoped<TInterface, TInstance>();
                        break;

                    case MimiServiceType.Transient:
                        @this.AddTransient<TInterface, TInstance>();
                        break;

                    case MimiServiceType.Static:
                        @this.AddStatic<TInterface, TInstance>();
                        break;

                    default:
                        throw new InvalidOperationException(nameof(MimiServiceTypeAttribute.ServiceType));
                }
            }
            else
            {
                switch (serviceType)
                {
                    case MimiServiceType.Singleton:
                        @this.AddSingleton<TInterface, TInstance>(factory);
                        break;

                    case MimiServiceType.Scoped:
                        @this.AddScoped<TInterface, TInstance>(factory);
                        break;

                    case MimiServiceType.Transient:
                        @this.AddTransient<TInterface, TInstance>(factory);
                        break;

                    case MimiServiceType.Static:
                        @this.AddStatic<TInterface, TInstance>(factory);
                        break;

                    default:
                        throw new InvalidOperationException(nameof(MimiServiceTypeAttribute.ServiceType));
                }
            }
        }

        private static bool AllNot<T>(this IServiceCollection @this)
        {
            return @this.All(e => e.ServiceType != typeof(T));
        }
    }
}
