using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    /// <summary>
    /// List型のデータストアを表現する為のインターフェースです。
    /// </summary>
    /// <typeparam name="TValue">要素の型</typeparam>
    public interface IRepositoryAsList<TValue> : IRepository<TValue>, IList<TValue>
    {
    }
}