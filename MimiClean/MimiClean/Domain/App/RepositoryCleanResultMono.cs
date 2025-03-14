namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;
    using StudioIdGames.MimiClean.Collections;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// 値の取得に失敗する可能性のある単一値型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResultMono<TValue> : RepositoryMono<CleanResultBoxed<TValue>>, IAppRepositoryCleanResultMono<TValue>
    {
        /// <inheritdoc/>
        [Obsolete("Use IMonoValueCleanResult and CachingCollection<TValue>")]
        public abstract class DefaultValues : CachingCollection<TValue>, ICleanResultMonoCollection<TValue>
        {
            /// <inheritdoc/>
            public CleanResult<TValue> Value => GetValueProtected();

            CleanResultBoxed<TValue> IMonoCollection<CleanResultBoxed<TValue>>.Value => Value.Box();

            /// <inheritdoc/>
            public override CleanResult<int> GetCount()
            {
                var v = GetValueProtected();
                return v.As(v ? 1 : 0);
            }

            /// <inheritdoc/>
            protected override CleanResult<TValue> GetValueProtected(int index)
            {
                return GetValueProtected();
            }

            /// <inheritdoc/>
            protected abstract CleanResult<TValue> GetValueProtected();

            /// <inheritdoc/>
            public virtual CleanResult<TValue> GetValue(CancellationToken cancellationToken) => Value;

            /// <inheritdoc/>
            public IEnumerable<CleanResultBoxed<TValue>> GetValues(CancellationToken cancellationToken)
            {
                return new CleanResultBoxed<TValue>[]
                {
                    GetValue(cancellationToken).Box(),
                };
            }
        }

        /// <inheritdoc/>
        public abstract class CleanResultMonoValue : ICleanResultMonoCollection<TValue>
        {
            /// <inheritdoc/>
            public virtual CleanResult<TValue> Value => GetValue(default);

            /// <inheritdoc/>
            public int Count
            {
                get
                {
                    var v = Value;
                    return v.As(v.IsSuccess ? 1 : 0);
                }
            }

            /// <inheritdoc/>
            CleanResultBoxed<TValue> IMonoCollection<CleanResultBoxed<TValue>>.Value => Value.Box();

            /// <inheritdoc/>
            public IEnumerable<CleanResultBoxed<TValue>> GetValues(CancellationToken cancellationToken)
            {
                return new CleanResultBoxed<TValue>[]
                {
                    GetValue(cancellationToken).Box(),
                };
            }

            /// <inheritdoc/>
            public IEnumerator<CleanResultBoxed<TValue>> GetEnumerator()
            {
                yield return Value.Box();
            }

            /// <inheritdoc/>
            public abstract CleanResult<TValue> GetValue(CancellationToken cancellationToken);

            IEnumerator IEnumerable.GetEnumerator()
            {
                yield return Value.Box();
            }
        }

        /// <inheritdoc/>
        protected sealed override IMonoCollection<CleanResultBoxed<TValue>> ValueProtected => ValueCleanResultProtected;

        /// <summary>
        /// <see cref="ValueProtected"/> として利用する <see cref="ICleanResultMonoCollection{TResult}"/>
        /// </summary>
        protected abstract ICleanResultMonoCollection<TValue> ValueCleanResultProtected { get; }

        /// <inheritdoc />
        public new CleanResult<TValue> Value => ValueCleanResultProtected.Value;

        /// <inheritdoc/>
        public CleanResult<TValue> GetValue(CancellationToken cancellationToken) => ValueCleanResultProtected.GetValue(cancellationToken);

        /// <inheritdoc/>
        public IEnumerable<CleanResultBoxed<TValue>> GetValues(CancellationToken cancellationToken)
        {
            return new CleanResultBoxed<TValue>[] { GetValue(cancellationToken).Box() };
        }
    }
}
