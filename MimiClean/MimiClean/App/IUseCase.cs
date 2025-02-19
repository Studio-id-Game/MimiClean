namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// 操作を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">入力型</typeparam>
    /// <typeparam name="TOutput">出力型</typeparam>
    public interface IUseCase<TInput, TOutput>
    {
        /// <summary>
        /// 操作を実行し、結果を取得します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        CleanResult<TOutput> Excute(in CleanResult<TInput> input);
    }

    /// <summary>
    /// 操作を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">入力型</typeparam>
    public interface IUseCase<TInput> : IUseCase<TInput, CleanResult.Void>
    {
    }

}