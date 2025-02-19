namespace StudioIdGames.MimiClean.Adapter
{
    /// <summary>
    /// 戻り値を持たない <see cref="App.IUseCase{,}"/> に対応した、環境層への戻り値のない応答を表現するインターフェースです。
    /// </summary>
    public interface IPresenter : IPresenter<CleanResult.Void>
    {
    }

    /// <summary>
    /// 環境層への戻り値のない応答を表現するインターフェースです。
    /// </summary>
    /// <typeparam name="TOutput">組み合わせる <see cref="App.IUseCase{,}"/> のアウトプットの型</typeparam>
    public interface IPresenter<TOutput> : IPresenter<TOutput, CleanResult.Void>
    {
    }

    /// <summary>
    /// 環境層への応答を表現するインターフェースです。
    /// </summary>
    /// <typeparam name="TOutput">組み合わせる <see cref="App.IUseCase{,}"/> のアウトプットの型</typeparam>
    /// <typeparam name="TResult">環境層への応答の戻り値の型</typeparam>
    public interface IPresenter<TOutput, TResult>
    {
        /// <summary>
        /// <see cref="App.IUseCase{TInput, TOutput}"/> の結果を受け取って、環境層への操作と応答を行います。
        /// </summary>
        /// <param name="usecaseOutput"><see cref="App.IUseCase{,}"/> の結果</param>
        /// <returns>環境層への応答</returns>
        CleanResult<TResult> Present(in CleanResult<TOutput> usecaseOutput);
    }
}
