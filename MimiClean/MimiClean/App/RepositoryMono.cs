namespace StudioIdGames.MimiClean.App
{
    using IApp;
    using StudioIdGames.MimiClean.Collections;
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

        /// <inheritdoc/>
        [System.Obsolete("Use MonoCollection<TValue>")]
        public class MonoValue : MonoCollection<TValue>
        {
            /// <summary>
            /// コンストラクター
            /// </summary>
            /// <param name="value">ストアする単一の値</param>
            public MonoValue(TValue value = default) : base(value)
            {
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
