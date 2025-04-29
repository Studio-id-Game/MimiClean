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
        /// <summary>
        /// <see cref="ValuesProtected"/> として利用する <see cref="IMonoCollection{TValue}"/>
        /// </summary>
        protected abstract IMonoCollection<TValue> ValueProtected { get; }

        /// <inheritdoc/>
        public TValue Value => ValueProtected.Value;

        /// <inheritdoc/>
        protected override sealed IReadOnlyCollection<TValue> ValuesProtected => ValueProtected;
    }
}
