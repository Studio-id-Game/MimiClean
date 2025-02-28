using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// <see cref="MimiServiceCollection"/> が利用する、デフォルトファクトリー関数を登録出来るクラスです。
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public static class MimiServiceDefault<TInterface>
            where TInterface : class, IMimiService
    {
        internal static int Priority { get; set; } = -1;

        internal static Func<IServiceProvider, TInterface> Factory { get; set; }

        internal static bool TryGetFactory(out Func<IServiceProvider, TInterface> factory)
        {
            factory = Factory;
            return factory != null;
        }

        /// <summary>
        /// <typeparamref name="TInterface"/>にデフォルトで使用するカスタムファクトリー関数を登録します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <param name="container">対象のContainer</param>
        /// <param name="factory">カスタムファクトリー関数</param>
        /// <param name="priority">優先度</param>
        public static void Set(MimiServiceContainer container, Func<IServiceProvider, TInterface> factory, int priority = 0)
        {
            if (Priority <= priority)
            {
                Priority = priority;
                Factory = factory;
                container.Add(factory);
            }
        }

        /// <summary>
        /// <typeparamref name="TInterface"/>にデフォルトで使用するTypeとして<typeparamref name="TInstance"/>を利用します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <typeparam name="TInstance">利用するType</typeparam>
        /// <param name="container">対象のContainer</param>
        /// <param name="priority">優先度</param>
        public static void Set<TInstance>(MimiServiceContainer container, int priority = 0)
            where TInstance : class, TInterface
        {
            if (Priority <= priority)
            {
                Priority = priority;

                Func<IServiceProvider, TInstance> factory = SetFactory<TInstance>;
                Factory = factory;
                container.Add<TInterface, TInstance>(factory);
            }
        }

        /// <summary>
        /// <typeparamref name="TInterface"/>として<typeparamref name="TRefTo"/>を参照します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <typeparam name="TRefTo">参照するType</typeparam>
        /// <param name="container">対象のContainer</param>
        /// <param name="priority">優先度</param>
        public static void Ref<TRefTo>(MimiServiceContainer container, int priority = 0)
            where TRefTo : class, TInterface
        {
            if (Priority <= priority)
            {
                Priority = priority;

                Func<IServiceProvider, TRefTo> factory = RefFactory<TRefTo>;
                Factory = factory;
                container.Add<TInterface, TRefTo>(factory);
            }
        }

        /// <summary>
        /// <see cref="Ref{TRefTo}(MimiServiceContainer, int)"/>で利用するファクトリー関数と同じ動作を表します。
        /// </summary>
        /// <typeparam name="TRefTo">参照するType</typeparam>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static TRefTo RefFactory<TRefTo>(IServiceProvider serviceProvider)
            where TRefTo : class, TInterface
        {
            return serviceProvider.GetMimiService<TRefTo>();
        }

        /// <summary>
        /// <see cref="Set{TInstance}(MimiServiceContainer, int)"/>で利用するファクトリー関数と同じ動作を表します。
        /// </summary>
        /// <typeparam name="TInstance">利用するType</typeparam>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static TInstance SetFactory<TInstance>(IServiceProvider serviceProvider)
        {
            return ActivatorUtilities.CreateInstance<TInstance>(serviceProvider);
        }
    }
}
