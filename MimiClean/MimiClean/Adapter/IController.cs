namespace StudioIdGames.MimiClean.Adapter
{
    /// <summary>
    /// <see cref="Controller{TInput, TOutput, TResult}"/>の操作を抽象化するためのインターフェースです。
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// この操作を実行し、結果を取得します。
        /// </summary>
        /// <returns>実行結果</returns>
        CleanResult<object> Invoke();
    }
}
