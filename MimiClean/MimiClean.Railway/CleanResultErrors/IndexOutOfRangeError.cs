namespace StudioIdGames.MimiClean.Railway.CleanResultErrors
{
    /// <summary>
    /// インデックスが見つからなかった場合のエラー
    /// </summary>
    public class IndexOutOfRangeError : NotFoundKeyError
    {
        /// <summary>
        /// エラーを作成します。
        /// </summary>
        /// <param name="index">インデックスの値</param>
        /// <param name="hostName">捜索対象の表示名</param>
        public IndexOutOfRangeError(int index, string hostName = null) : base(index, index.ToString(), hostName)
        {
        }
    }
}
