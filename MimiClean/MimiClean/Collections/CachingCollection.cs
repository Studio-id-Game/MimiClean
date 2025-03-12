namespace StudioIdGames.MimiClean.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 結果をキャッシュ可能なコレクション
    /// </summary>
    /// <typeparam name="TValue">値</typeparam>
    public abstract class CachingCollection<TValue> : CachingBase<int, TValue>, IReadOnlyCollection<CleanResultBoxed<TValue>>
    {
        /// <inheritdoc/>
        public CleanResult<TValue> this[int index] => GetValue(index);

        /// <inheritdoc/>
        public override sealed CleanResult<TValue> GetValue(int index)
        {
            if (index < 0 || Count <= index)
            {
                return CleanResult<TValue>.Failed(new IndexOutOfRangeException(nameof(index)));
            }

            return base.GetValue(index);
        }

        /// <inheritdoc/>
        protected abstract override CleanResult<TValue> GetValueProtected(int index);

        /// <inheritdoc/>
        public IEnumerator<CleanResultBoxed<TValue>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return GetValue(i).Box();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
