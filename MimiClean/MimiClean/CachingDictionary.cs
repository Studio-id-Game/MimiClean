using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudioIdGames.MimiClean
{
    /// <inheritdoc cref="Collections.CachingDictionary{TKey, TValue}"/>
    [Obsolete("Use Collections.CachingDictionary<TKey, TValue>")]
    public abstract class CachingDictionary<TKey, TValue> : CachingBase<TKey, TValue>, IReadOnlyDictionary<TKey, CleanResultBoxed<TValue>>
    {
        /// <inheritdoc/>
        public CachingDictionary(IEqualityComparer<TKey> comparer = null) : base(comparer)
        {
        }

        /// <inheritdoc/>
        public CleanResult<TValue> this[TKey key] => GetValue(key);

        CleanResultBoxed<TValue> IReadOnlyDictionary<TKey, CleanResultBoxed<TValue>>.this[TKey key] => GetValue(key).Box();

        /// <inheritdoc/>
        public abstract IEnumerable<TKey> Keys { get; }

        /// <inheritdoc/>
        public IEnumerable<CleanResultBoxed<TValue>> Values => Keys.Select(k => GetValue(k).Box());

        /// <inheritdoc/>
        public bool ContainsKey(TKey key)
        {
            return Keys.Contains(key);
        }

        /// <inheritdoc/>
        public bool TryGetValue(TKey key, out CleanResult<TValue> value, CleanResultState when = CleanResultState.Success)
        {
            value = GetValue(key);
            return value.State == when;
        }

        /// <inheritdoc/>
        public bool TryGetValue(TKey key, out CleanResultBoxed<TValue> value, CleanResultState when = CleanResultState.Success)
        {
            value = GetValue(key).Box();
            return value.State == when;
        }

        /// <inheritdoc/>
        public bool TryGetValue(TKey key, out CleanResultBoxed<TValue> value) => TryGetValue(key, out value);

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<TKey, CleanResultBoxed<TValue>>> GetEnumerator()
        {
            foreach (var key in Keys)
            {
                yield return new KeyValuePair<TKey, CleanResultBoxed<TValue>>(key, GetValue(key).Box());
            }
        }

        /// <inheritdoc/>
        public sealed override CleanResult<TValue> GetValue(TKey key)
        {
            return base.GetValue(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
