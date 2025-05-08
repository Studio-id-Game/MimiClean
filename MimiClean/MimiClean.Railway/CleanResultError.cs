namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>のためのエラーを表現するクラス
    /// </summary>
    public abstract class CleanResultError
    {
        /// <summary>
        /// エラーの内容を表す文字列
        /// </summary>
        public abstract string Message { get; }

        /// <summary>
        /// return <c>$"{GetType()} : {Message}"</c>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{GetType()} : {Message}";
        }
    }
}
