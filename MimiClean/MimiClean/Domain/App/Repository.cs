using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;

    public abstract class Repository<TValue> : IAppRepository<TValue>
    {
        public int Count => ValuesProtected.Count;

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

    public abstract class RepositoryMono<TValue> : Repository<TValue>, IAppRepositoryMono<TValue>
    {
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

        protected abstract MonoValue ValueProtected { get; }

        public TValue Value => ValueProtected.Value;

        protected sealed override IReadOnlyCollection<TValue> ValuesProtected => ValueProtected;
    }

    public abstract class RepositoryMap<TKey, TValue> : Repository<KeyValuePair<TKey, TValue>>, IAppRepositoryMap<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>
    {
        /// <inheritdoc/>
        public TValue this[TKey key] => MapProtected[key];

        /// <inheritdoc/>
        public IEnumerable<TKey> Keys => MapProtected.Keys;

        /// <inheritdoc/>
        public IEnumerable<TValue> Values => MapProtected.Values;

        protected abstract IReadOnlyDictionary<TKey, TValue> MapProtected { get; }

        protected sealed override IReadOnlyCollection<KeyValuePair<TKey, TValue>> ValuesProtected => MapProtected;

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
