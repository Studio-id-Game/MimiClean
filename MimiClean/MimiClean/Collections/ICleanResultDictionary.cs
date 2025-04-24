namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// キャンセル可能な<see cref="CleanResultBoxed{TResult}"/>の辞書を抽象化します
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ICleanResultDictionary<TKey, TResult> : IReadOnlyDictionary<TKey, CleanResultBoxed<TResult>>, ICollectionCancellation<KeyValuePair<TKey, CleanResultBoxed<TResult>>>
    {
        /// <summary>
        /// キャンセルを考慮して、指定したキーに対応する要素を取得します
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        CleanResult<TResult> GetValue(TKey key, CancellationToken cancellationToken);
    }
}
