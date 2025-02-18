using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.App
{
    public abstract class RepositoryAsSingle<TInterface, TSelf, TValue> : Repository<TInterface, TSelf, TValue>, IRepositoryAsSingle<TValue>
        where TInterface : class, IRepositoryAsSingle<TValue>
        where TSelf : RepositoryAsSingle<TInterface, TSelf, TValue>, TInterface, new()
    {
        public abstract TValue Value { get; }

        public IEnumerator<TValue> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Value;
        }
    }
}