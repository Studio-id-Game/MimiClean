namespace StudioIdGames.MimiClean.Railway.CleanResultErrors
{
    /// <summary>
    /// 何かが見つからなかった場合のエラー
    /// </summary>
    public class NotFoundError : CleanResultError
    {
        /// <inheritdoc/>
        public override string Message => $"Not found {Name}";

        /// <summary>
        /// みつからなかった物の表示名
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// エラーを作成します。
        /// </summary>
        /// <param name="name">表示名</param>
        public NotFoundError(string name = null)
        {
            Name = name ?? "Some thing";
        }
    }
}
