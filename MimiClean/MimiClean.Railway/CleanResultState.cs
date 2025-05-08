namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>で利用する、操作の状態を表します。
    /// </summary>
    public enum CleanResultState : byte
    {
        /// <summary>
        /// 未定義
        /// </summary>
        None = 0,

        /// <summary>
        /// 操作中、障害やユーザーによる中断操作が発生せず、操作を完了した状態を表します。
        /// </summary>
        Success = 1,

        /// <summary>
        /// 操作中、予期された障害が発生し、操作を続行できなかった状態を表します。
        /// </summary>
        Failed = 2,

        /// <summary>
        ///  操作中、ユーザーによる中断操作が発生し、操作を中断した状態を表します。
        /// </summary>
        Canceled = 3,

        /// <summary>
        /// 操作後、結果値のリソースを破棄し終えた状態を表します。
        /// </summary>
        Used = 4,
    }
}
