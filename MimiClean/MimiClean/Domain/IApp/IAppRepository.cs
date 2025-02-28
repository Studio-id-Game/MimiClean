using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain.IApp
{
    /// <summary>
    /// 全てのデータストアを抽象化します。
    /// </summary>
    public interface IAppRepository : IEnumerable, IAppService
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
    public interface IAppRepository<TValue> : IAppRepository, IEnumerable<TValue>, IReadOnlyCollection<TValue>
    {
    }

    /// <summary>
    /// 単一値型データストアを抽象化します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryMono<TValue> : IAppRepository<TValue>
    {
        /// <summary>
        /// ストアされている単一の値
        /// </summary>
        TValue Value { get; }
    }

    /// <summary>
    /// 辞書型データストアを抽象化します。
    /// </summary>
    /// <typeparam name="TKey">ストアに利用するKeyの型</typeparam>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryMap<TKey, TValue> : IAppRepository<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue>
    {
    }
}
