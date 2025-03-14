namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections.Generic;

    /// <summary>
    /// キャンセル可能な<see cref="CleanResultBoxed{TValue}"/>のコレクションを抽象化します
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface ICleanResultCollection<TResult> : IReadOnlyCollection<CleanResultBoxed<TResult>>, ICollectionCancellation<CleanResultBoxed<TResult>>
    {
    }
}
