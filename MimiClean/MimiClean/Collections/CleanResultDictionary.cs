namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class CleanResultDictionary<TKey, TValue, TResult> : IReadOnlyDictionary<TKey, CleanResultBoxed<TResult>>
    {
        public CleanResultDictionary(IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            Dictionary = dictionary;
        }

        protected IReadOnlyDictionary<TKey, TValue> Dictionary { get; }

        public CleanResult<TResult> this[TKey key]
        {
            get
            {
                if (Dictionary.TryGetValue(key, out var result))
                {
                    return GetResult(key, result, true);
                }
                else
                {
                    return GetResult(key, default, false);
                }
            }
        }

        CleanResultBoxed<TResult> IReadOnlyDictionary<TKey, CleanResultBoxed<TResult>>.this[TKey key] => this[key].Box();

        public IEnumerable<TKey> Keys => Dictionary.Keys;

        public IEnumerable<CleanResultBoxed<TResult>> Values => Keys.Select(key => this[key].Box());

        public int Count => Dictionary.Count;

        public bool ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<TKey, CleanResultBoxed<TResult>>> GetEnumerator()
        {
            foreach (var key in Keys)
            {
                yield return new KeyValuePair<TKey, CleanResultBoxed<TResult>>(key, this[key].Box());
            }
        }

        public bool TryGetValue(TKey key, out CleanResult<TResult> result)
        {
            if (Dictionary.TryGetValue(key, out var value))
            {
                result = GetResult(key, value, true);
                return true;
            }
            else
            {
                result = GetResult(key, value, false);
                return false;
            }
        }

        bool IReadOnlyDictionary<TKey, CleanResultBoxed<TResult>>.TryGetValue(TKey key, out CleanResultBoxed<TResult> result)
        {
            if (TryGetValue(key, out var value))
            {
                result = value.Box();
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected abstract CleanResult<TResult> GetResult(TKey key, TValue value, bool isDefined);
    }
}
