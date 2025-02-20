using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    /// <summary>
    /// 単一データのデータストアを表現する為のインターフェースです。
    /// </summary>
    /// <typeparam name="TValue">要素の型</typeparam>
    public interface IRepositoryAsSingle<TValue> : IRepository<TValue>, IEnumerable<TValue>
    {
        /// <summary>
        /// ストアされた値
        /// </summary>
        TValue Value { get; }
    }
}