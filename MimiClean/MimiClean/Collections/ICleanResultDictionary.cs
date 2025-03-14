namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections.Generic;

    /// <summary>
    /// キャンセル可能な<see cref="CleanResultBoxed{TResult}"/>の辞書を抽象化します
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ICleanResultDictionary<TKey, TResult> : IReadOnlyDictionary<TKey, CleanResultBoxed<TResult>>, ICollectionCancellation<KeyValuePair<TKey, CleanResultBoxed<TResult>>>
    {
    }
}
