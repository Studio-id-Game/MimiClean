using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain.IApp
{
    /// <summary>
    /// データストアを表現する為のインターフェースです。
    /// </summary>
    public interface IAppRepository : IEnumerable, IAppService
    {
        int Count { get; }
    }

    /// <summary>
    /// リスト型データストアを表現する為のインターフェースです。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepository<TValue> : IAppRepository, IEnumerable<TValue>, IReadOnlyCollection<TValue>
    {
    }

    /// <summary>
    /// 単一値型データストアを表現する為のインターフェースです。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryMono<TValue> : IAppRepository<TValue>
    {
        TValue Value { get; }
    }

    /// <summary>
    /// 辞書型データストアを表現する為のインターフェースです。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryMap<TKey, TValue> : IAppRepository<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue>
    {
    }
}
