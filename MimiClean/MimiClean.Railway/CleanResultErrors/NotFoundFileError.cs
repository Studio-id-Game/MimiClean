namespace StudioIdGames.MimiClean.Railway.CleanResultErrors
{
    /// <summary>
    /// ファイルが見つからなかった場合のエラー
    /// </summary>
    public class NotFoundFileError : NotFoundError
    {
        /// <inheritdoc/>
        public override string Message => $"NotFoundFile Error : {FilePath}";

        /// <summary>
        /// ファイルのローカルパスやURL
        /// </summary>
        public string FilePath => Name;

        /// <summary>
        /// エラーを作成します。
        /// </summary>
        /// <param name="filepath">ファイルのローカルパスやURL</param>
        public NotFoundFileError(string filepath) : base(filepath)
        {
        }
    }
}
