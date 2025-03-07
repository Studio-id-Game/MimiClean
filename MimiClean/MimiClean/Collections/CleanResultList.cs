namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class CleanResultList<TValue, TResult> : IReadOnlyList<CleanResultBoxed<TResult>>
    {
        private readonly IReadOnlyList<TValue> values;

        public CleanResultList(IReadOnlyList<TValue> values)
        {
            this.values = values;
        }

        public int Count => values.Count;

        public CleanResult<TResult> this[int index] => GetResult(values[index]);

        CleanResultBoxed<TResult> IReadOnlyList<CleanResultBoxed<TResult>>.this[int index] => this[index].Box();

        protected abstract CleanResult<TResult> GetResult(in TValue value);

        public IEnumerator<CleanResultBoxed<TResult>> GetEnumerator()
        {
            foreach (var item in values)
            {
                yield return GetResult(item).Box();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
