using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace StudioIdGames.MimiClean
{
    public abstract class CachingCollection<TValue> : CachingBase<int, TValue>, IReadOnlyCollection<CleanResultBoxed<TValue>>
    {
        public object this[int index] => GetValue(index);

        public override sealed CleanResult<TValue> GetValue(int index)
        {
            if (index < 0 || Count <= index)
            {
                return CleanResult<TValue>.Failed(new IndexOutOfRangeException(nameof(index)));
            }

            return base.GetValue(index);
        }

        protected abstract override CleanResult<TValue> GetValueProtected(int index);

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
