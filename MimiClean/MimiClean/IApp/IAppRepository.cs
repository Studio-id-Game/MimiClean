namespace StudioIdGames.MimiClean.IApp
{
    using MimiCleanContainer;
    using StudioIdGames.MimiClean.Collections;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 全てのデータストアを抽象化します。
    /// </summary>

    public interface IAppRepository : IEnumerable, IMimiService
    {
        /// <summary>
        /// ストアされているデータの件数
        /// </summary>
        int Count { get; }
    }

    /// <summary>
    /// リスト型データストアを抽象化します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepository<out TValue> : IAppRepository, IReadOnlyCollection<TValue>
    {
    }

    /// <summary>
    /// 単一値型データストアを抽象化します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryMono<out TValue> : IAppRepository, IMonoCollection<TValue>
    {
    }

    /// <summary>
    /// 辞書型データストアを抽象化します。
    /// </summary>
    /// <typeparam name="TKey">ストアに利用するKeyの型</typeparam>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryMap<TKey, TValue> : IAppRepository, IReadOnlyDictionary<TKey, TValue>
    {
    }
}
