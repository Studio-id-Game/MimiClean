using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App.IAdapter
{
    /// <summary>
    /// 全ての操作を抽象化します。
    /// </summary>
    public interface IAdapterController : IScopedService
    {
        /// <summary>
        /// この操作を実行し、結果を取得します。
        /// </summary>
        /// <returns>実行結果</returns>
        CleanResult<object> Invoke();
    }

    /// <summary>
    /// 入力、出力、戻り値を持った操作を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">入力の型</typeparam>
    /// <typeparam name="TOutput">出力の型</typeparam>
    /// <typeparam name="TResult">戻り値の型</typeparam>
    public interface IAdapterController<TInput, TOutput, TResult> : IAdapterController
    {
        /// <inheritdoc cref="IAdapterController.Invoke"/>
        new CleanResult<TResult> Invoke();
    }

    /// <summary>
    /// 入力と出力を持ち、戻り値を持たない操作を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">入力の型</typeparam>
    /// <typeparam name="TOutput">出力の型</typeparam>
    public interface IAdapterController<TInput, TOutput> : IAdapterController<TInput, TOutput, CleanResult.Void>
    {
    }

    /// <summary>
    /// 入力を持ち、出力と戻り値を持たない操作を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">入力の型</typeparam>
    public interface IAdapterController<TInput> : IAdapterController<TInput, CleanResult.Void>
    {
    }

    /// <summary>
    /// 入力も出力も戻り値も持たない操作を抽象化します。
    /// </summary>
    public interface IAdapterControllerVoid : IAdapterController<CleanResult.Void>
    {
    }
}
