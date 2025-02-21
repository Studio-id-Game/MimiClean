using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace StudioIdGames.MimiCleanContainer
{
    internal class MimiServiceCollection : ServiceCollection
    {
        public void AddStatic<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            TInstance Factory(IServiceProvider serviceProvider)
            {
                var instance = (factory?.Invoke(serviceProvider)) ??
                    ActivatorUtilities.CreateInstance<TInstance>(serviceProvider) ??
                    throw new InvalidOperationException($"Can't create instance of the type {typeof(TInstance).Name}.");

                StaticServices<TInterface>.Instance = instance;
                StaticServices<TInstance>.Instance = instance;

                return instance;
            }

            this.AddSingleton<TInterface, TInstance>(Factory);
        }

        public void AddStatic<TInterface>(Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            AddStatic<TInterface, TInterface>(factory);
        }

        public void AddService<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            var type = MimiServiceTypeAttributeCache.Get<TInstance>();
            if (type == MimiServiceType.None)
            {
                throw new InvalidOperationException($"Please add {nameof(MimiServiceTypeAttribute)} to {typeof(TInstance).Name}");
            }
            AddService<TInterface, TInstance>(type, factory);
        }

        public void AddService<TInterface>(Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            AddService<TInterface, TInterface>(factory);
        }

        private void AddService<TInterface, TInstance>(MimiServiceType serviceType, Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            if (factory == null)
            {
                factory = MimiServiceDefault<TInstance>.Factory;
            }

            if (factory == null)
            {
                switch (serviceType)
                {
                    case MimiServiceType.Singleton:
                        this.AddSingleton<TInterface, TInstance>();
                        break;

                    case MimiServiceType.Scoped:
                        this.AddScoped<TInterface, TInstance>();
                        break;

                    case MimiServiceType.Transient:
                        this.AddTransient<TInterface, TInstance>();
                        break;

                    case MimiServiceType.Static:
                        AddStatic<TInterface, TInstance>();
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
                        this.AddSingleton<TInterface, TInstance>(factory);
                        break;

                    case MimiServiceType.Scoped:
                        this.AddScoped<TInterface, TInstance>(factory);
                        break;

                    case MimiServiceType.Transient:
                        this.AddTransient<TInterface, TInstance>(factory);
                        break;

                    case MimiServiceType.Static:
                        AddStatic<TInterface, TInstance>(factory);
                        break;

                    default:
                        throw new InvalidOperationException(nameof(MimiServiceTypeAttribute.ServiceType));
                }
            }
        }
    }
}
