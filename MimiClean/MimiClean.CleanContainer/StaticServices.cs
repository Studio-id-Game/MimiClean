using System;

namespace StudioIdGames.MimiClean.CleanContainer
{
    /// <summary>
    /// Static Type Caching を利用して、<see cref="StaticService{TInterface, TSelf}"/>で実装された機能を管理します。
    /// </summary>
    /// <typeparam name="TInterface">機能を定義しているインターフェース</typeparam>
    internal static class StaticServices<TInterface>
        where TInterface : class, IMimiService
    {
        private static TInterface instance;
        private static readonly object lockObj = new object();

        /// <summary>
        /// <see cref="TInterface"/>として利用するインスタンス。nullを取得しようとした場合エラーをスローします。
        /// </summary>
        public static TInterface Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        throw new InvalidOperationException($"Need to set Instance before accessing {typeof(TInterface)}.");
                    }

                    return instance;
                }
            }
            set
            {
                lock (lockObj)
                {
                    instance = value;
                }
            }
        }

        public static bool IsUsed
        {
            get
            {
                lock (lockObj)
                {
                    return instance != null;
                }
            }
        }
    }
}
