using System;

namespace StudioIdGames.MimiCleanContainer
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = true, AllowMultiple = false)]
    public sealed class MimiServiceTypeAttribute : Attribute
    {
        public MimiServiceTypeAttribute(MimiServiceType serviceType)
        {
            ServiceType = serviceType;
        }

        public MimiServiceType ServiceType { get; }
    }
}
