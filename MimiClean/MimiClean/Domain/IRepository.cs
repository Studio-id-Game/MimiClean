using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    /// <summary>
    /// データストアを表現する為のインターフェースです。
    /// </summary>
    public interface IRepository : IEnumerable
    {
    }

    /// <summary>
    /// データストアを表現する為のインターフェースです。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IRepository<TValue> : IRepository, IEnumerable<TValue>
    {
    }
}