using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// <see cref="MimiServiceContainer"/> でServiceの <see cref="MimiServiceType"/> を特定するために必要な属性です。
    /// <list type="number">
    ///     <item>
    ///         この属性を持つ class を継承した class は、継承元の属性が適用されます。この属性は上書きする事が出来ます。
    ///     </item>
    ///     <item>
    ///         この属性を持つ interface を継承した interface は、継承元の属性が適用されます。この属性は上書きする事が出来ません。
    ///     </item>
    ///     <item>
    ///         class が継承する、全ての interface のこの属性の内容は、全て一致している必要があります。ただし、(4.) の仕様を利用してこの問題を回避する事ができます。
    ///     </item>
    ///     <item>
    ///         class 自身がこの属性を持つ場合、継承先で上書きされない限りその内容は（interface や 親 class の属性を無視して）最も優先されます。
    ///     </item>
    /// </list>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = true, AllowMultiple = false)]
    public sealed class MimiServiceTypeAttribute : Attribute
    {
        public MimiServiceTypeAttribute(MimiServiceType serviceType)
        {
            ServiceType = serviceType;
        }

        /// <summary>
        /// 型に結びつけられた、<see cref="MimiServiceType"/>
        /// </summary>
        public MimiServiceType ServiceType { get; }
    }
}
