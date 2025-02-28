using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// <see cref="Microsoft.Extensions.DependencyInjection"/> で定義されるオブジェクトに、独自の動作を加えた拡張メソッドを追加します。
    /// </summary>
    public static class MimiServiceProviderExtension
    {
        /// <summary>
        /// <see cref="IServiceProvider"/> から、MimiServiceが実装するカスタム動作を考慮して <typeparamref name="T"/> 型のServiceを取得します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static T GetMimiService<T>(this IServiceProvider serviceProvider)
            where T : class, IMimiService
        {
            return StaticServices<T>.IsUsed ? StaticServices<T>.Instance : serviceProvider.GetService<T>();
        }

        /// <summary>
        /// <see cref="IServiceProvider"/> を、MimiServiceが実装するカスタム動作を考慮できる <see cref="MimiCleanContainer.MimiServiceProvider"/> に変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static MimiServiceProvider AsMimiServiceProvider(this IServiceProvider serviceProvider)
        {
            if (serviceProvider is MimiServiceProvider mimi)
            {
                return mimi;
            }
            else
            {
                return new MimiServiceProvider(serviceProvider);
            }
        }

        /// <summary>
        /// <see cref="IServiceScope"/> から、MimiServiceが実装するカスタム動作を考慮できる <see cref="MimiCleanContainer.MimiServiceProvider"/> を取得します。
        /// </summary>
        /// <param name="serviceScope"></param>
        /// <returns></returns>
        public static MimiServiceProvider MimiServiceProvider(this IServiceScope serviceScope)
        {
            return serviceScope.ServiceProvider.AsMimiServiceProvider();
        }
    }
}
