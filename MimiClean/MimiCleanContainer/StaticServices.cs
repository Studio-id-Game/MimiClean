using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// Static Type Caching を利用して、<see cref="StaticService{TInterface, TSelf}"/>で実装された機能を管理します。
    /// </summary>
    /// <typeparam name="TInterface">機能を定義しているインターフェース</typeparam>
    internal static class StaticServices<TInterface>
        where TInterface : class, IMimiService
    {
        private static TInterface instance;
        private static bool isUsed;

        /// <summary>
        /// <see cref="TInterface"/>として利用するインスタンス。nullを取得しようとした場合エラーをスローします。
        /// </summary>
        public static TInterface Instance
        {
            get
            {
                return instance ?? throw new InvalidOperationException($"Need to set Instance before accessing {typeof(TInterface)}.");
            }
            set
            {
                if (isUsed)
                {
                    throw new InvalidOperationException($"Can't set twice Instance property of {typeof(TInterface)}.");
                }
                instance = value;
                isUsed = instance != null;
            }
        }

        public static bool IsUsed
        {
            get
            {
                return isUsed;
            }
        }
    }
}
