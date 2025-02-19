using System.Collections.Generic;

namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// Key-Value Pair型のデータストアを表現する為のインターフェースです。
    /// </summary>
    /// <typeparam name="TKey">インデックスの型</typeparam>
    /// <typeparam name="TValue">要素の型</typeparam>
    public interface IRepositoryAsDictionary<TKey, TValue> : IRepository<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
    {
    }
}