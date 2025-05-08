namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// <see cref="ICleanResult{TResult}"/>の更新に利用される関数を定義します
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="result"></param>
    /// <param name="state"></param>
    /// <param name="errorChain"></param>
    /// <returns></returns>
    public delegate void CleanResultChainer<TResult>(TResult result, CleanResultState state, CleanResultErrorChain errorChain);

    /// <summary>
    /// <see cref="ICleanResult{TResult}"/>の更新に利用される関数を定義します
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="result"></param>
    /// <param name="state"></param>
    /// <param name="errorChain"></param>
    /// <returns></returns>
    public delegate T CleanResultChainer<TResult, T>(TResult result, CleanResultState state, CleanResultErrorChain errorChain);

    /// <summary>
    /// <see cref="ICleanResult{TResult}"/>の更新に利用される関数を定義します
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="result"></param>
    /// <param name="state"></param>
    /// <param name="errorClose"></param>
    /// <returns></returns>
    public delegate void CleanResultCloser<TResult>(TResult result, CleanResultState state, CleanResultErrorClose errorClose);

    /// <summary>
    /// <see cref="ICleanResult{TResult}"/>の更新に利用される関数を定義します
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="result"></param>
    /// <param name="state"></param>
    /// <param name="errorClose"></param>
    /// <returns></returns>
    public delegate T CleanResultCloser<TResult, T>(TResult result, CleanResultState state, CleanResultErrorClose errorClose);
}
