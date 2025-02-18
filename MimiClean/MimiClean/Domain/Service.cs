﻿namespace StudioIdGames.MimiClean.Domain
{
    public class Service<TInterface>
        where TInterface : class, IService
    {
        /// <summary>
        /// 現在利用されているDomainService。nullの場合エラーをスローします。
        /// </summary>
        public static TInterface I => SingletonMap<TInterface>.Instance;
    }

    /// <summary>
    /// ベクトル演算など、完全な依存性注入が困難なフレームワーク動作をサービスとして提供します。
    /// 代替可能でシングルトン（static）なサービスを実装する事が出来ます。
    /// <see cref="IService"/>の派生で抽象化した操作を実体化します。
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public abstract class Service<TInterface, TSelf> : Singleton<TInterface, TSelf>
        where TInterface : class, IService
        where TSelf : Service<TInterface, TSelf>, TInterface, new()
    {
    }
}
