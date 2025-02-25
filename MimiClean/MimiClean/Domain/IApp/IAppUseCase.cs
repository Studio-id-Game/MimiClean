using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.IApp
{
    public interface IAppUseCase : ITransientService
    {
        /// <summary>
        /// 操作を実行し、結果を取得します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        CleanResult<object> Excute(in CleanResult<object> input);
    }

    /// <summary>
    /// 操作を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">入力型</typeparam>
    /// <typeparam name="TOutput">出力型</typeparam>
    public interface IAppUseCase<TInput, TOutput> : IAppUseCase
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
    public interface IAppUseCase<TInput> : IAppUseCase<TInput, CleanResult.Void>
    {
    }

    /// <summary>
    /// 操作を抽象化します。
    /// </summary>
    public interface IAppUseCaseVoid : IAppUseCase<CleanResult.Void>
    {
    }
}
