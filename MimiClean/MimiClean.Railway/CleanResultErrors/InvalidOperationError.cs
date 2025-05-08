namespace StudioIdGames.MimiClean.Railway.CleanResultErrors
{
    /// <summary>
    /// 状態に対して誤った操作をした場合のエラー
    /// </summary>
    public class InvalidOperationError : CleanResultError
    {
        /// <inheritdoc/>
        public override string Message => Reason;

        /// <summary>
        /// 理由
        /// </summary>
        public string Reason { get; }

        /// <summary>
        /// エラーを作成します。
        /// </summary>
        /// <param name="reason">理由</param>
        public InvalidOperationError(string reason)
        {
            Reason = reason;
        }
    }
}
