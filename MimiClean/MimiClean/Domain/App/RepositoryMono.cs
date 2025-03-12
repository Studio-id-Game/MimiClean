namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;
    using StudioIdGames.MimiClean.Collections;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 単一値型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryMono<TValue> : Repository<TValue>, IAppRepositoryMono<TValue>
    {
        /// <inheritdoc/>
        [System.Obsolete("Use IMonoCollection<TValue>")]
        public interface IMonoValue : IMonoCollection<TValue>
        {
        }

        /// <summary>
        /// 単一値を表すコレクション
        /// </summary>
        public class MonoValue : IMonoCollection<TValue>
        {
            /// <inheritdoc/>
            public TValue Value { get; set; }

            /// <inheritdoc/>
            public int Count => 1;

            /// <summary>
            /// コンストラクター
            /// </summary>
            /// <param name="value">ストアする単一の値</param>
            public MonoValue(TValue value = default)
            {
                Value = value;
            }

            /// <inheritdoc/>
            public IEnumerator<TValue> GetEnumerator()
            {
                yield return Value;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                yield return Value;
            }
        }

        /// <summary>
        /// <see cref="ValuesProtected"/> として利用する <see cref="IMonoCollection{TValue}"/>
        /// </summary>
        protected abstract IMonoCollection<TValue> ValueProtected { get; }

        /// <inheritdoc/>
        public TValue Value => ValueProtected.Value;

        /// <inheritdoc/>
        protected sealed override IReadOnlyCollection<TValue> ValuesProtected => ValueProtected;
    }
}
