using System;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean
{
    /// <inheritdoc cref="Collections.CachingBase{TKey, TValue}"/>
    [Obsolete("Use Collections.CachingBase<TKey, TValue>")]
    public abstract class CachingBase<TKey, TValue> : Collections.CachingBase<TKey, TValue>
    {
        /// <inheritdoc cref="Collections.CachingBase{TKey, TValue}(IEqualityComparer{TKey})"/>
        public CachingBase(IEqualityComparer<TKey> comparer = null) : base(comparer)
        {
        }
    }
}
