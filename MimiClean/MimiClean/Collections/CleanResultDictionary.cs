namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// <see cref="ICleanResultDictionary{TKey, TResult}"/>の基本的な実装を提供します。
    /// </summary>
    /// <typeparam name="TKey">キー</typeparam>
    /// <typeparam name="TValue">変換過程値</typeparam>
    /// <typeparam name="TResult">結果値</typeparam>
    public abstract class CleanResultDictionary<TKey, TValue, TResult> : ICleanResultDictionary<TKey, TResult>
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="dictionary">元となる辞書</param>
        public CleanResultDictionary(IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            Dictionary = dictionary;
        }

        /// <summary>
        /// 元となる辞書
        /// </summary>
        protected IReadOnlyDictionary<TKey, TValue> Dictionary { get; }

        /// <inheritdoc cref="IReadOnlyDictionary{TKey, TValue}.this[TKey]"/>
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

        /// <inheritdoc/>
        public IEnumerable<TKey> Keys => Dictionary.Keys;

        /// <inheritdoc/>
        public IEnumerable<CleanResultBoxed<TResult>> Values => Keys.Select(key => this[key].Box());

        /// <inheritdoc/>
        public int Count => Dictionary.Count;

        /// <inheritdoc/>
        public bool ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<TKey, CleanResultBoxed<TResult>>> GetEnumerator()
        {
            foreach (var key in Keys)
            {
                yield return new KeyValuePair<TKey, CleanResultBoxed<TResult>>(key, this[key].Box());
            }
        }

        /// <inheritdoc cref="IReadOnlyDictionary{TKey, TValue}.TryGetValue"/>
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

        /// <summary>
        /// 内部辞書の検索結果から、最終的な値の作成を実装します。
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="value">内部辞書の検索結果</param>
        /// <param name="isDefined">キーが存在しているか</param>
        /// <returns></returns>
        protected abstract CleanResult<TResult> GetResult(TKey key, TValue value, bool isDefined);

        /// <inheritdoc/>
        public virtual IEnumerable<KeyValuePair<TKey, CleanResultBoxed<TResult>>> GetValues(CancellationToken cancellationToken)
        {
            return this;
        }
    }
}
