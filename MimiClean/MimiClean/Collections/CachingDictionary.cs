namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 結果をキャッシュ可能な辞書
    /// </summary>
    /// <typeparam name="TKey">キー</typeparam>
    /// <typeparam name="TValue">値</typeparam>
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

        /// <summary>
        /// 特定の条件の場合のみ、値を取得します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="when">条件</param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out CleanResult<TValue> value, CleanResultState when = CleanResultState.Success)
        {
            value = GetValue(key);
            return value.State == when;
        }

        /// <summary>
        /// 特定の条件の場合のみ、値を取得します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="when">条件</param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out CleanResultBoxed<TValue> value, CleanResultState when)
        {
            value = GetValue(key).Box();
            return value.State == when;
        }

        /// <inheritdoc/>
        public bool TryGetValue(TKey key, out CleanResultBoxed<TValue> value)
        {
            value = GetValue(key).Box();
            return value.IsSuccess;
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<TKey, CleanResultBoxed<TValue>>> GetEnumerator()
        {
            foreach (var key in Keys)
            {
                yield return new KeyValuePair<TKey, CleanResultBoxed<TValue>>(key, GetValue(key).Box());
            }
        }

        /// <inheritdoc/>
        public override sealed CleanResult<TValue> GetValue(TKey key)
        {
            return base.GetValue(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
