using Microsoft.Extensions.DependencyInjection;
using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// <see cref="MimiServiceCollectionExtension"/> が利用する、デフォルトファクトリー関数を登録出来るクラスです。
    /// </summary>
    public static class MimiServiceDefault
    {
        internal static int Priority { get; private set; } = -1;

        internal static Action<IServiceCollection> AddDefaultService { get; set; }

        /// <summary>
        /// <typeparamref name="TInterface"/>にデフォルトで使用するカスタムファクトリー関数を登録します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <param name="factory">カスタムファクトリー関数</param>
        /// <param name="priority">優先度</param>
        public static void Set<TInterface>(Func<IServiceProvider, TInterface> factory = null, int priority = 0)
            where TInterface : class, IMimiService
        {
            if (Priority <= priority)
            {
                Priority = priority;
                AddDefaultService += (IServiceCollection col) =>
                {
                    col.TryAddService(factory);
                };
            }
        }

        /// <summary>
        /// <typeparamref name="TInterface"/>にデフォルトで使用するTypeとして<typeparamref name="TInstance"/>を利用します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <typeparam name="TInstance">利用するType</typeparam>
        /// <param name="factory">カスタムファクトリー関数</param>
        /// <param name="priority">優先度</param>
        public static void Set<TInterface, TInstance>(Func<IServiceProvider, TInstance> factory = null, int priority = 0)
            where TInterface : class, IMimiService
            where TInstance : class, TInterface
        {
            if (Priority <= priority)
            {
                Priority = priority;
                AddDefaultService += (IServiceCollection col) =>
                {
                    col.TryAddService<TInterface, TInstance>(factory);
                };
            }
        }

        /// <summary>
        /// <typeparamref name="TInterface"/>として<typeparamref name="TRefTo"/>を参照します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <typeparam name="TRefTo">参照するType</typeparam>
        /// <param name="priority">優先度</param>
        public static void Ref<TInterface, TRefTo>(int priority = 0)
            where TInterface : class, IMimiService
            where TRefTo : class, TInterface
        {
            if (Priority <= priority)
            {
                Priority = priority;
                AddDefaultService += (IServiceCollection col) =>
                {
                    col.TryAddService<TInterface>(p =>
                    {
                        return p.GetMimiService<TRefTo>();
                    });
                };
            }
        }
    }

    /// <summary>
    /// <see cref="MimiServiceCollectionExtension"/> が利用する、デフォルトファクトリー関数を登録出来るクラスです。
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    [Obsolete("Should use static class MimiServiceDefault (without type parameter)")]
    public static class MimiServiceDefault<TInterface>
            where TInterface : class, IMimiService
    {
        /// <summary>
        /// <typeparamref name="TInterface"/>にデフォルトで使用するカスタムファクトリー関数を登録します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <param name="factory">カスタムファクトリー関数</param>
        /// <param name="priority">優先度</param>
        public static void Set(MimiServiceContainer _ = null, Func<IServiceProvider, TInterface> factory = null, int priority = 0)
        {
            MimiServiceDefault.Set(factory, priority);
        }

        /// <summary>
        /// <typeparamref name="TInterface"/>にデフォルトで使用するTypeとして<typeparamref name="TInstance"/>を利用します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <typeparam name="TInstance">利用するType</typeparam>
        /// <param name="priority">優先度</param>
        public static void Set<TInstance>(MimiServiceContainer _ = null, int priority = 0)
            where TInstance : class, TInterface
        {
            MimiServiceDefault.Set<TInterface, TInstance>(null, priority);
        }

        /// <summary>
        /// <typeparamref name="TInterface"/>として<typeparamref name="TRefTo"/>を参照します。優先度が高いものが優先され、同じ優先度の場合は後から設定されたものが優先されます。
        /// </summary>
        /// <typeparam name="TRefTo">参照するType</typeparam>
        /// <param name="priority">優先度</param>
        public static void Ref<TRefTo>(MimiServiceContainer _ = null, int priority = 0)
            where TRefTo : class, TInterface
        {
            MimiServiceDefault.Ref<TInterface, TRefTo>(priority);
        }
    }
}
