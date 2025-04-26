namespace StudioIdGames.MimiClean.Collections
{
    using StudioIdGames.MimiClean.Railway;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// キャンセル可能な<see cref="CleanResultBoxed{TValue}"/>のコレクションを抽象化します
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface ICleanResultCollection<TResult> : IReadOnlyCollection<CleanResultBoxed<TResult>>, ICollectionCancellation<CleanResultBoxed<TResult>>
    {
        /// <summary>
        /// キャンセルを考慮して、指定したインデックスに対応する要素を取得します
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        new CleanResult<TResult> ElementAt(int index, CancellationToken cancellationToken);
    }
}
