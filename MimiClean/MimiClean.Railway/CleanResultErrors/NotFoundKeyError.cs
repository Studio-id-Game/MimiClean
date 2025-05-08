namespace StudioIdGames.MimiClean.Railway.CleanResultErrors
{
    /// <summary>
    /// キーが見つからなかった場合のエラー
    /// </summary>
    public class NotFoundKeyError : NotFoundError
    {
        /// <inheritdoc/>
        public override string Name => $"{KeyName} in {HostName}";

        /// <summary>
        /// キーの値
        /// </summary>
        public object Key { get; }

        /// <summary>
        /// キーの表示名
        /// </summary>
        public string KeyName { get; }

        /// <summary>
        /// 捜索対象の表示名
        /// </summary>
        public string HostName { get; }

        /// <summary>
        /// エラーを作成します。
        /// </summary>
        /// <param name="key">キーの値</param>
        /// <param name="keyName">キーの表示名</param>
        /// <param name="hostName">捜索対象の表示名</param>
        public NotFoundKeyError(object key, string keyName = null, string hostName = null)
        {
            Key = key;
            KeyName = keyName ?? key.ToString();
            HostName = hostName ?? "Some thing";
        }
    }
}
