namespace StudioIdGames.MimiClean.App
{
    using IApp;
    using StudioIdGames.MimiClean.Collections;
    using StudioIdGames.MimiClean.Railway;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// 値の取得に失敗する可能性のある辞書型データストアを実装します。
    /// </summary>
    /// <typeparam name="TKey">ストアに利用するKeyの型</typeparam>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResultMap<TKey, TValue> : RepositoryMap<TKey, CleanResultBoxed<TValue>>, IAppRepositoryCleanResultMap<TKey, TValue>
    {
        /// <inheritdoc/>
        protected override IReadOnlyDictionary<TKey, CleanResultBoxed<TValue>> MapProtected => CleanResultMapProtected;

        /// <summary>
        /// <see cref="MapProtected"/> として利用する <see cref="ICleanResultDictionary{Tkey,TResult}"/>
        /// </summary>
        protected abstract ICleanResultDictionary<TKey, TValue> CleanResultMapProtected { get; }

        /// <inheritdoc/>
        public KeyValuePair<TKey, CleanResultBoxed<TValue>> ElementAt(int index, CancellationToken cancellationToken)
        {
            return CleanResultMapProtected.ElementAt(index, cancellationToken);
        }

        /// <inheritdoc/>
        public CleanResult<TValue> GetValue(TKey key, CancellationToken cancellationToken)
        {
            return CleanResultMapProtected.GetValue(key, cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<KeyValuePair<TKey, CleanResultBoxed<TValue>>> GetValues(CancellationToken cancellationToken)
        {
            return CleanResultMapProtected.GetValues(cancellationToken);
        }
    }
}
