namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// 操作を抽象化します。
    /// </summary>
    /// <typeparam name="TInputData">入力型</typeparam>
    /// <typeparam name="TOutputData">出力型</typeparam>
    public interface IUseCase<TInputData, TOutputData>
    {
        /// <summary>
        /// 操作を実行し、結果を取得します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        CleanResult<TOutputData> Excute(in CleanResult<TInputData> input);
    }

    /// <summary>
    /// 操作を抽象化します。
    /// </summary>
    /// <typeparam name="TInputData">入力型</typeparam>
    public interface IUseCase<TInputData> : IUseCase<TInputData, CleanResult.Void>
    {
    }

}