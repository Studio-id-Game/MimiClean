namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;
    using StudioIdGames.MimiClean.Collections;
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
    }
}
