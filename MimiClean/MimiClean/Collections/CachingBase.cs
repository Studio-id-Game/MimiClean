using System;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Collections
{
    public abstract class CachingBase<TKey, TValue>
    {
        private Lazy<CleanResultBoxed<int>> count;

        protected Dictionary<TKey, TValue> Cache { get; }

        public CachingBase(IEqualityComparer<TKey> comparer = null)
        {
            Cache = new Dictionary<TKey, TValue>(comparer);
            CountReset();
        }

        public int Count => count.Value.Result;

        public virtual CleanResult<TValue> GetValue(TKey key)
        {
            if (Cache.TryGetValue(key, out var value))
            {
                return CleanResult<TValue>.Success(value);
            }
            else
            {
                var crValue = GetValueProtected(key);

                if (crValue)
                {
                    Cache[key] = crValue.Result;
                }

                return crValue;
            }
        }

        protected abstract CleanResult<TValue> GetValueProtected(TKey key);

        public void CacheReset(bool countReset = true)
        {
            Cache.Clear();
            if (countReset)
            {
                CountReset();
            }
        }

        public void CountReset()
        {
            count = new Lazy<CleanResultBoxed<int>>(() =>
            {
                return GetCount().Box();
            });
        }

        public abstract CleanResult<int> GetCount();
    }
}
