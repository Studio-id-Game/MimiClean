namespace StudioIdGames.MimiClean.Adapter
{
    /// <summary>
    /// 環境層からの入力を表現するインターフェースです。
    /// </summary>
    /// <typeparam name="TInput">環境層から得る入力オブジェクトの型</typeparam>
    public interface IGateway<TInput>
    {
        /// <summary>
        /// 環境層からの入力を取得します。
        /// </summary>
        /// <returns>取得した入力オブジェクト</returns>
        CleanResult<TInput> MakeInput();
    }
}