using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// 全ての登録機能は、IServiceCollection.(Try)Add~~を利用しているので、IServiceProvider.GetServiceに対応している
    /// </summary>
    internal static class MimiServiceCollectionExtension
    {
        public static MimiServiceProvider BuildMimiServiceProvider(this IServiceCollection @this, bool clearDefaults = true)
        {
            MimiServiceDefault.AddDefaultService?.Invoke(@this);

            if (clearDefaults)
            {
                MimiServiceDefault.AddDefaultService = null;
            }

            return new MimiServiceProvider(@this.BuildServiceProvider());
        }

        internal static bool AllNot<T>(this IServiceCollection @this)
        {
            return @this.All(e => e.ServiceType != typeof(T));
        }
    }
}
