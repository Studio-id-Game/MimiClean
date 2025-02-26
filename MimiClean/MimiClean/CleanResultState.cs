namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>で利用する、操作の状態を表します。
    /// </summary>
    public enum CleanResultState
    {
        /// <summary>
        /// 操作が成功し、Resultが得られている状態を表します。
        /// </summary>
        Success,

        /// <summary>
        /// 操作が中断し、Resultが得られているか分からない状態を表します。
        /// </summary>
        Canceled,

        /// <summary>
        /// 操作が失敗し、Resultが得られていない状態を表します。
        /// </summary>
        Failed
    }
}
