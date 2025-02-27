using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.IApp
{
    /// <summary>
    /// 全ての動作を抽象化します。
    /// </summary>
    public interface IAppUseCase : ITransientService
    {
        /// <summary>
        /// 動作を実行し、結果を取得します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        CleanResult<object> Excute(in CleanResult<object> input);
    }

    /// <summary>
    /// 入力と出力のある動作を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">入力型</typeparam>
    /// <typeparam name="TOutput">出力型</typeparam>
    public interface IAppUseCase<TInput, TOutput> : IAppUseCase
    {
        /// <summary>
        /// 動作を実行し、結果を取得します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        CleanResult<TOutput> Excute(in CleanResult<TInput> input);
    }

    /// <summary>
    /// 入力のみがある動作を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">入力型</typeparam>
    public interface IAppUseCase<TInput> : IAppUseCase<TInput, CleanResult.Void>
    {
    }

    /// <summary>
    /// 入力も出力もない動作を抽象化します。
    /// </summary>
    public interface IAppUseCaseVoid : IAppUseCase<CleanResult.Void>
    {
    }
}
