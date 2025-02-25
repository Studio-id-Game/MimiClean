using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App.IAdapter
{
    /// <summary>
    /// <see cref="IAdapterController{TInput, TOutput, TResult}"/>の操作を抽象化するためのインターフェースです。
    /// </summary>
    public interface IAdapterController : IScopedService
    {
        /// <summary>
        /// この操作を実行し、結果を取得します。
        /// </summary>
        /// <returns>実行結果</returns>
        CleanResult<object> Invoke();
    }

    public interface IAdapterController<TInput, TOutput, TResult> : IAdapterController
    {
        new CleanResult<TResult> Invoke();
    }

    public interface IAdapterController<TInput, TOutput> : IAdapterController<TInput, TOutput, CleanResult.Void>
    {
    }

    public interface IAdapterController<TInput> : IAdapterController<TInput, CleanResult.Void>
    {
    }

    public interface IAdapterControllerVoid : IAdapterController<CleanResult.Void>
    {
    }
}
