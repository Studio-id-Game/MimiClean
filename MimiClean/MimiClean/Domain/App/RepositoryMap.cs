namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;
    using System.Collections.Generic;

    /// <summary>
    /// 辞書型データストアを実装します。
    /// </summary>
    /// <typeparam name="TKey">ストアに利用するKeyの型</typeparam>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryMap<TKey, TValue> : Repository<KeyValuePair<TKey, TValue>>, IAppRepositoryMap<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>
    {
        /// <inheritdoc/>
        public TValue this[TKey key] => MapProtected[key];

        /// <inheritdoc/>
        public IEnumerable<TKey> Keys => MapProtected.Keys;

        /// <inheritdoc/>
        public IEnumerable<TValue> Values => MapProtected.Values;

        /// <summary>
        /// <see cref="ValuesProtected"/> として利用する <see cref="IReadOnlyDictionary{TKey, TValue}"/>
        /// </summary>
        protected abstract IReadOnlyDictionary<TKey, TValue> MapProtected { get; }

        /// <inheritdoc/>
        protected override sealed IReadOnlyCollection<KeyValuePair<TKey, TValue>> ValuesProtected => MapProtected;

        /// <inheritdoc/>
        public bool ContainsKey(TKey key)
        {
            return MapProtected.ContainsKey(key);
        }

        /// <inheritdoc/>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return MapProtected.TryGetValue(key, out value);
        }
    }
}
