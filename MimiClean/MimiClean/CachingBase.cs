using System;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean
{
    [Obsolete("Use Collections.CachingBase<TKey, TValue>")]
    public abstract class CachingBase<TKey, TValue> : Collections.CachingBase<TKey, TValue>
    {
        public CachingBase(IEqualityComparer<TKey> comparer = null) : base(comparer)
        {
        }
    }
}
