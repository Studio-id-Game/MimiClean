namespace StudioIdGames.MimiClean.App
{
    using IApp;
    using StudioIdGames.MimiClean.Collections;
    using StudioIdGames.MimiClean.Railway;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// 値の取得に失敗する可能性のあるリスト型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResult<TValue> : Repository<CleanResultBoxed<TValue>>, IAppRepositoryCleanResult<TValue>
    {
        /// <inheritdoc/>
        protected override sealed IReadOnlyCollection<CleanResultBoxed<TValue>> ValuesProtected => CleanResultValuesProtected;

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
