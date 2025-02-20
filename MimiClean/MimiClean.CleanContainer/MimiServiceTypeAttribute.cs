using System;

namespace StudioIdGames.MimiClean.CleanContainer
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
