using StudioIdGames.MimiClean.Domain;
using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// 単一データのデータストアを表現する為の抽象クラスです。
    /// </summary>
    /// <typeparam name="TValue">要素の型</typeparam>
    public abstract class RepositoryAsSingle<TInterface, TSelf, TValue> : Repository<TInterface, TSelf, TValue>, IRepositoryAsSingle<TValue>
        where TInterface : class, IRepositoryAsSingle<TValue>
        where TSelf : RepositoryAsSingle<TInterface, TSelf, TValue>, TInterface, new()
    {
        /// <inheritdoc/>
        public abstract TValue Value { get; }

        public override IEnumerator<TValue> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Value;
        }
    }
}