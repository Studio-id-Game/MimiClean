using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App.IAdapter
{
    using IApp;

    /// <summary>
    /// 全ての動作に対する応答を抽象化します。
    /// </summary>
    public interface IAdapterPresenter : ITransientService
    {
        /// <summary>
        /// 動作の結果を受け取って、応答を行い、操作としての戻り値を返します。
        /// </summary>
        /// <param name="usecaseOutput">動作の結果</param>
        /// <returns>動作としての戻り値</returns>
        CleanResult<object> Present(in CleanResult<object> usecaseOutput);
    }

    /// <summary>
    /// 出力を持った動作に対する、戻り値を持った応答を抽象化します。
    /// </summary>
    /// <typeparam name="TOutput">動作の出力の型</typeparam>
    /// <typeparam name="TResult">操作の戻り値の型</typeparam>
    public interface IAdapterPresenter<TOutput, TResult> : IAdapterPresenter
    {
        /// <inheritdoc cref="IAdapterPresenter.Present(in CleanResult{object})"/>
        CleanResult<TResult> Present(in CleanResult<TOutput> usecaseOutput);
    }

    /// <summary>
    /// 出力を持った動作に対する、戻り値を持たない応答を抽象化します。
    /// </summary>
    /// <typeparam name="TOutput">動作の出力の型</typeparam>
    public interface IAdapterPresenter<TOutput> : IAdapterPresenter<TOutput, CleanResult.Void>
    {
    }

    /// <summary>
    /// 出力を持たない動作に対する、戻り値を持たない応答を抽象化します。
    /// </summary>
    public interface IAdapterPresenterVoid : IAdapterPresenter<CleanResult.Void>
    {
    }
}
