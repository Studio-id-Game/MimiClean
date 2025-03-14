using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// カスタムした<see cref="IServiceCollection"/>をカプセル化したDIServiceContainerです。
    /// </summary>
    public class MimiServiceContainer
    {
        private readonly IServiceCollection services;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public MimiServiceContainer()
        {
            services = new ServiceCollection();
            services.AddTransient<MimiServiceProvider>();
        }

        /// <summary>
        /// <typeparamref name="TInterface"/> で定義されたサービスとして、<typeparamref name="TInstance"/> で実装されたサービスを登録します。
        /// <paramref name="factory"/> がnullの場合、<see cref="MimiServiceDefault{TInterface}"/>で定義されたもの、
        /// それもnullの場合はコンストラクタの自動解決を試みます。このメソッドはチェーン可能です。
        /// </summary>
        /// <typeparam name="TInterface">サービスの定義</typeparam>
        /// <typeparam name="TInstance">サービスの実装</typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        public MimiServiceContainer Add<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory = null)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            services.AddService<TInterface, TInstance>(factory);
            return this;
        }

        /// <summary>
        /// <typeparamref name="TInterface"/> で定義されたサービスを登録します。
        /// <paramref name="factory"/> がnullの場合、<see cref="MimiServiceDefault{TInterface}"/>で定義されたものを使用します。
        /// このメソッドはチェーン可能です。
        /// </summary>
        /// <typeparam name="TInterface">サービスの定義</typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        public MimiServiceContainer Add<TInterface>(Func<IServiceProvider, TInterface> factory = null)
            where TInterface : class, IMimiService
        {
            services.AddService(factory);
            return this;
        }

        /// <summary>
        /// <see cref="MimiServiceProvider"/> をビルドし、依存関係を自動で解決したプロバイダーを返します。
        /// </summary>
        /// <returns></returns>
        public MimiServiceProvider BuildServiceProvider()
        {
            return services.BuildMimiServiceProvider();
        }
    }
}
