using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App.IAdapter
{
    using IApp;

    /// <summary>
    /// 環境層への応答を表現するインターフェースです。
    /// </summary>
    public interface IAdapterPresenter : ITransientService
    {
        /// <summary>
        /// <see cref="IAppUseCase{TInput, TOutput}"/> の結果を受け取って、環境層への操作と応答を行います。
        /// </summary>
        /// <param name="usecaseOutput"><see cref="IAppUseCase{,}"/> の結果</param>
        /// <returns>環境層への応答</returns>
        CleanResult<object> Present(in CleanResult<object> usecaseOutput);
    }

    /// <summary>
    /// 環境層への応答を表現するインターフェースです。
    /// </summary>
    /// <typeparam name="TOutput">組み合わせる <see cref="IAppUseCase{,}"/> のアウトプットの型</typeparam>
    /// <typeparam name="TResult">環境層への応答の戻り値の型</typeparam>
    public interface IAdapterPresenter<TOutput, TResult> : IAdapterPresenter
    {
        /// <summary>
        /// <see cref="IAppUseCase{TInput, TOutput}"/> の結果を受け取って、環境層への操作と応答を行います。
        /// </summary>
        /// <param name="usecaseOutput"><see cref="IAppUseCase{,}"/> の結果</param>
        /// <returns>環境層への応答</returns>
        CleanResult<TResult> Present(in CleanResult<TOutput> usecaseOutput);
    }

    /// <summary>
    /// 環境層への戻り値のない応答を表現するインターフェースです。
    /// </summary>
    /// <typeparam name="TOutput">組み合わせる <see cref="IAppUseCase{,}"/> のアウトプットの型</typeparam>
    public interface IAdapterPresenter<TOutput> : IAdapterPresenter<TOutput, CleanResult.Void>
    {
    }

    /// <summary>
    /// 戻り値を持たない <see cref="IAppUseCase{,}"/> に対応した、環境層への戻り値のない応答を表現するインターフェースです。
    /// </summary>
    public interface IAdapterPresenterVoid : IAdapterPresenter<CleanResult.Void>
    {
    }
}
