using System;
using System.Reflection;

namespace StudioIdGames.MimiClean.CleanContainer
{
    internal static class MimiServiceTypeAttributeCache
    {
        private static class Cache<T>
        {
            public static readonly Lazy<MimiServiceType> serviceType = new Lazy<MimiServiceType>(() =>
            {
                var att = GetAttribute(typeof(T));
                if (att == null) return MimiServiceType.None;
                return att.ServiceType;

            });
        }

        public static MimiServiceType Get<T>() => Cache<T>.serviceType.Value;

        private static MimiServiceTypeAttribute GetAttribute(Type t)
        {
            var ret = t.GetCustomAttribute<MimiServiceTypeAttribute>(true);

            if (ret == null)
            {
                bool find = false;
                foreach (var item in t.GetInterfaces())
                {
                    var ret2 = item.GetCustomAttribute<MimiServiceTypeAttribute>(true);
                    if (ret2 != null)
                    {
                        if (find)
                        {
                            if (ret.ServiceType != ret2.ServiceType)
                            {
                                throw new InvalidOperationException($"MimiServiceTypeAttributes in the type {t.Name} are in conflict. Either the attribute must be added to the class or the value of the attribute must match in all inherited interfaces.");
                            }
                        }
                        else
                        {
                            ret = ret2;
                            find = true;
                        }
                    }
                }
            }

            return ret;
        }
    }
}
