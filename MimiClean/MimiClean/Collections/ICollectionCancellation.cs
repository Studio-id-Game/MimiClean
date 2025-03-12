namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// キャンセル可能な列挙要素を抽象化します。
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface ICollectionCancellation<TValue>
    {
        /// <summary>
        /// キャンセルを考慮して、<typeparamref name="TValue"/>を列挙します
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IEnumerable<TValue> GetValues(CancellationToken cancellationToken);
    }
}
