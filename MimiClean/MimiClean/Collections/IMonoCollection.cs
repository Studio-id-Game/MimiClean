namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections.Generic;

    /// <summary>
    /// 単一値を表すコレクションのインターフェース
    /// </summary>
    public interface IMonoCollection<out TValue> : IReadOnlyCollection<TValue>
    {
        /// <summary>
        /// ストアされている単一の値
        /// </summary>
        TValue Value { get; }
    }
}
