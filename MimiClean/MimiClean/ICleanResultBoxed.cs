namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// <see cref="CleanResultBoxed{TResult}"/>を戻り値型に依存せずに扱うためのインターフェース
    /// </summary>
    public interface ICleanResultBoxed
    {
        /// <summary>
        /// 操作の状態を表します
        /// </summary>
        CleanResultState State { get; }

        /// <summary>
        /// 操作に失敗している場合、エラーの内容を表します
        /// </summary>
        CleanResultError Error { get; }

        /// <summary>
        /// 操作が成功した場合のみtrueです。
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// 操作が中断した場合のみtrueです。
        /// </summary>
        bool IsCanceled { get; }

        /// <summary>
        /// 操作が失敗した場合のみtrueです。
        /// </summary>
        bool IsFailed { get; }
    }
}
