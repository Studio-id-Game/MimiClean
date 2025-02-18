using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.App
{
    public abstract class RepositoryAsDictionary<TInterface, TSelf, TKey, TValue> : Repository<TInterface, TSelf, TValue>, IDictionary<TKey, TValue>, IRepositoryAsDictionary<TKey, TValue>
        where TInterface : class, IRepositoryAsDictionary<TKey, TValue>
        where TSelf : RepositoryAsDictionary<TInterface, TSelf, TKey, TValue>, TInterface, new()
    {
        public TValue this[TKey key] { get => Pairs[key]; set => Pairs[key] = value; }

        public ICollection<TKey> Keys => Pairs.Keys;

        public ICollection<TValue> Values => Pairs.Values;

        public int Count => Pairs.Count;

        public bool IsReadOnly => Pairs.IsReadOnly;

        protected abstract IDictionary<TKey, TValue> Pairs { get; }

        public void Add(TKey key, TValue value)
        {
            Pairs.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Pairs.Add(item);
        }

        public void Clear()
        {
            Pairs.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Pairs.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return Pairs.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Pairs.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Pairs.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            return Pairs.Remove(key);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Pairs.Remove(item);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return Pairs.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Pairs).GetEnumerator();
        }
    }
}