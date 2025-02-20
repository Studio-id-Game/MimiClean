using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace StudioIdGames.MimiClean.CleanContainer
{
    internal class MimiServiceCollection : ServiceCollection
    {
        public void AddStatic<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            if (factory == null)
            {
                factory = (p) => ActivateInstance<TInstance>();
            }

            var instance = (factory?.Invoke(null)) ??
                throw new InvalidOperationException($"This method requires factory argument, or MimiServiceDefault<{typeof(TInstance).Name}>.Factory or new() constructor.");

            StaticServices<TInterface>.Instance = instance;
            this.AddSingleton<TInterface, TInstance>(GetStatic<TInstance>);
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

        private static TInstance ActivateInstance<TInstance>()
            where TInstance : class
        {
            if (HasDefaultConstructor(typeof(TInstance)))
            {
                try
                {
                    return Activator.CreateInstance<TInstance>();
                }
                catch (Exception e)
                {
                    throw new InvalidProgramException("Standalone Service need default constructor.", e);
                }
            }
            else
            {
                return null;
            }
        }

        private static bool HasDefaultConstructor(Type type)
        {
            if (type.IsAbstract || type.IsInterface) return false;
            return type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null) != null;
        }

        private static TInterface GetStatic<TInterface>(IServiceProvider serviceProvider)
            where TInterface : class, IMimiService
        {
            var serviceType = MimiServiceTypeAttributeCache.Get<TInterface>();
            if (serviceType == MimiServiceType.Static)
            {
                return StaticServices<TInterface>.Instance;
            }
            else
            {
                return (TInterface)serviceProvider.GetService(typeof(TInterface));
            }
        }
    }
}
