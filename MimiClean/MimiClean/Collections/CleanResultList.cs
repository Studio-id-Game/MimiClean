namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// <see cref="ICleanResultCollection{TResult}"/>の基本的な実装を提供します。
    /// </summary>
    /// <typeparam name="TValue">変換過程値</typeparam>
    /// <typeparam name="TResult">結果値</typeparam>
    public abstract class CleanResultList<TValue, TResult> : IReadOnlyList<CleanResultBoxed<TResult>>, ICleanResultCollection<TResult>
    {
        private readonly IReadOnlyList<TValue> values;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="values">元となるリスト</param>
        public CleanResultList(IReadOnlyList<TValue> values)
        {
            this.values = values;
        }

        /// <inheritdoc/>
        public int Count => values.Count;

        /// <inheritdoc cref="IReadOnlyList{T}.this[int]"/>
        public CleanResult<TResult> this[int index] => GetResult(values[index]);

        CleanResultBoxed<TResult> IReadOnlyList<CleanResultBoxed<TResult>>.this[int index] => this[index].Box();

        /// <summary>
        /// 内部辞書の検索結果から、最終的な値の作成を実装します。
        /// </summary>
        /// <param name="value">変換過程値</param>
        /// <returns></returns>
        protected abstract CleanResult<TResult> GetResult(in TValue value);

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public virtual IEnumerable<CleanResultBoxed<TResult>> GetValues(CancellationToken cancellationToken)
        {
            return this;
        }
    }
}
