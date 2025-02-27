using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;

    /// <summary>
    /// リスト型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class Repository<TValue> : IAppRepository<TValue>
    {
        public int Count => ValuesProtected.Count;

        /// <summary>
        /// 内部のデータコレクション
        /// </summary>
        protected abstract IReadOnlyCollection<TValue> ValuesProtected { get; }

        public IEnumerator<TValue> GetEnumerator()
        {
            return ValuesProtected.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)ValuesProtected).GetEnumerator();
        }
    }

    /// <summary>
    /// 単一値型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryMono<TValue> : Repository<TValue>, IAppRepositoryMono<TValue>
    {
        /// <summary>
        /// 単一値を表すコレクション
        /// </summary>
        public class MonoValue : IReadOnlyCollection<TValue>
        {
            public TValue Value { get; set; }

            public int Count => 1;

            public MonoValue(TValue value = default)
            {
                Value = value;
            }

            public IEnumerator<TValue> GetEnumerator()
            {
                yield return Value;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                yield return Value;
            }
        }

        /// <summary>
        /// 内部の単一データコレクション
        /// </summary>
        protected abstract MonoValue ValueProtected { get; }

        public TValue Value => ValueProtected.Value;

        protected override sealed IReadOnlyCollection<TValue> ValuesProtected => ValueProtected;
    }

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

        /// <inheritdoc/>
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
