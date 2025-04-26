namespace StudioIdGames.MimiClean.App
{
    using IApp;
    using StudioIdGames.MimiClean.Collections;
    using StudioIdGames.MimiClean.Railway;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// 値の取得に失敗する可能性のあるリスト型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResult<TValue> : Repository<CleanResultBoxed<TValue>>, IAppRepositoryCleanResult<TValue>
    {
        /// <inheritdoc/>
        [Obsolete("Use ICleanResultCollection<TValue> and CachingCollection<TValue> ")]
        public abstract class DefaultValues : CachingCollection<TValue>, ICleanResultCollection<TValue>
        {
            /// <inheritdoc/>
            public IEnumerable<CleanResultBoxed<TValue>> GetValues(CancellationToken cancellationToken)
            {
                return this;
            }

            /// <inheritdoc/>
            public CleanResult<TValue> ElementAt(int index, CancellationToken cancellationToken)
            {
                if (0 <= index && index < Count)
                {
                    return this[index];
                }
                else
                {
                    return CleanResult<TValue>.Failed(new IndexOutOfRangeException(nameof(index)));
                }
            }

            CleanResultBoxed<TValue> ICollectionCancellation<CleanResultBoxed<TValue>>.ElementAt(int index, CancellationToken cancellationToken)
            {
                return ElementAt(index, cancellationToken).Box();
            }
        }

        /// <inheritdoc/>
        protected sealed override IReadOnlyCollection<CleanResultBoxed<TValue>> ValuesProtected => CleanResultValuesProtected;

        /// <summary>
        /// <see cref="ValuesProtected"/> として利用する <see cref="ICleanResultCollection{TResult}"/>
        /// </summary>
        protected abstract ICleanResultCollection<TValue> CleanResultValuesProtected { get; }

        /// <inheritdoc/>
        public IEnumerable<CleanResultBoxed<TValue>> GetValues(CancellationToken cancellationToken)
        {
            return CleanResultValuesProtected.GetValues(cancellationToken);
        }

        /// <inheritdoc/>
        public CleanResult<TValue> ElementAt(int index, CancellationToken cancellationToken)
        {
            return CleanResultValuesProtected.ElementAt(index, cancellationToken);
        }

        CleanResultBoxed<TValue> ICollectionCancellation<CleanResultBoxed<TValue>>.ElementAt(int index, CancellationToken cancellationToken)
        {
            return ElementAt(index, cancellationToken).Box();
        }
    }
}
