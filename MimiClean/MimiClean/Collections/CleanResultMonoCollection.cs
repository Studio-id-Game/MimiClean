namespace StudioIdGames.MimiClean.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    /// <inheritdoc cref="ICleanResultMonoCollection{TResult}"/>
    public abstract class CleanResultMonoCollection<TResult> : ICleanResultMonoCollection<TResult>
    {
        /// <inheritdoc/>
        public virtual CleanResult<TResult> Value => GetValue(CancellationToken.None);

        /// <inheritdoc/>
        public int Count => 1;

        /// <inheritdoc/>
        CleanResultBoxed<TResult> IMonoCollection<CleanResultBoxed<TResult>>.Value => Value.Box();

        /// <inheritdoc/>
        public IEnumerable<CleanResultBoxed<TResult>> GetValues(CancellationToken cancellationToken)
        {
            yield return GetValue(cancellationToken).Box();
        }

        /// <inheritdoc/>
        public IEnumerator<CleanResultBoxed<TResult>> GetEnumerator()
        {
            yield return Value.Box();
        }

        /// <inheritdoc/>
        public abstract CleanResult<TResult> GetValue(CancellationToken cancellationToken);

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Value.Box();
        }

        CleanResultBoxed<TResult> ICollectionCancellation<CleanResultBoxed<TResult>>.ElementAt(int index, CancellationToken cancellationToken)
        {
            if (index == 0)
            {
                return GetValue(cancellationToken).Box();
            }
            else
            {
                return CleanResult.Failed<TResult>(new IndexOutOfRangeException(nameof(index))).Box();
            }
        }
    }
}
