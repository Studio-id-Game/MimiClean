namespace StudioIdGames.MimiClean.Collections
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 結果をキャッシュ可能なコレクションの基礎
    /// </summary>
    /// <typeparam name="TKey">キー</typeparam>
    /// <typeparam name="TValue">値</typeparam>
    public abstract class CachingBase<TKey, TValue>
    {
        private Lazy<CleanResultBoxed<int>> count;

        /// <summary>
        /// 内部のキャッシュ
        /// </summary>
        protected Dictionary<TKey, TValue> Cache { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="comparer"></param>
        public CachingBase(IEqualityComparer<TKey> comparer = null)
        {
            Cache = new Dictionary<TKey, TValue>(comparer);
            CountReset();
        }

        /// <inheritdoc cref="IReadOnlyCollection{T}.Count"/>
        public int Count => count.Value.Result;

        /// <summary>
        /// キーに対応する値を取得します。キャッシュが利用可能な場合、キャッシュを利用します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual CleanResult<TValue> GetValue(TKey key)
        {
            if (Cache.TryGetValue(key, out var value))
            {
                return CleanResult<TValue>.Success(value);
            }
            else
            {
                var crValue = GetValueProtected(key);

                if (crValue)
                {
                    Cache[key] = crValue.Result;
                }

                return crValue;
            }
        }

        /// <summary>
        /// 値の取得を実装します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected abstract CleanResult<TValue> GetValueProtected(TKey key);

        /// <summary>
        /// キャッシュをリセットします。
        /// </summary>
        /// <param name="countReset">trueの場合、要素数を再取得します</param>
        public void CacheReset(bool countReset = true)
        {
            Cache.Clear();
            if (countReset)
            {
                CountReset();
            }
        }

        /// <summary>
        /// 要素数を再取得します。
        /// </summary>
        public void CountReset()
        {
            count = new Lazy<CleanResultBoxed<int>>(() =>
            {
                return GetCount().Box();
            });
        }

        /// <summary>
        /// 要素数の取得を実装します。
        /// </summary>
        /// <returns></returns>
        public abstract CleanResult<int> GetCount();
    }
}
