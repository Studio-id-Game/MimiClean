using System;
using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean
{
    /// <inheritdoc cref="Collections.CachingCollection{TValue}"/>
    [Obsolete("Use Collections.CachingCollection<TValue>")]
    public abstract class CachingCollection<TValue> : CachingBase<int, TValue>, IReadOnlyList<CleanResultBoxed<TValue>>
    {
        CleanResultBoxed<TValue> IReadOnlyList<CleanResultBoxed<TValue>>.this[int index] => this[index].Box();

        /// <inheritdoc/>
        public CleanResult<TValue> this[int index] => GetValue(index);

        /// <inheritdoc/>
        public sealed override CleanResult<TValue> GetValue(int index)
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
