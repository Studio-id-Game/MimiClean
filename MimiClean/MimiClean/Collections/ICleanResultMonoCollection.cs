namespace StudioIdGames.MimiClean.Collections
{
    using System.Threading;

    /// <summary>
    /// キャンセル可能な<see cref="CleanResultBoxed{TValue}"/>の単一値コレクションを抽象化します
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface ICleanResultMonoCollection<TResult> : IMonoCollection<CleanResultBoxed<TResult>>, ICollectionCancellation<CleanResultBoxed<TResult>>
    {
        /// <inheritdoc cref="IMonoCollection{TValue}.Value"/>
        new CleanResult<TResult> Value { get; }

        /// <summary>
        /// キャンセルを考慮して、ストアされている単一の値を取得します
        /// </summary>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns></returns>
        CleanResult<TResult> GetValue(CancellationToken cancellationToken);
    }
}
