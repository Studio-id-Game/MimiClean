namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// UseCaseを実装します。
    /// </summary>
    /// <typeparam name="TInput">入力オブジェクト</typeparam>
    /// <typeparam name="TOutput">出力オブジェクト</typeparam>
    public abstract class Interactor<TInput, TOutput> : IUseCase<TInput, TOutput>
    {
        /// <inheritdoc/>
        public virtual CleanResult<TOutput> Excute(in CleanResult<TInput> input)
        {
            return CleanResult<TOutput>.Failed(new InteractorError.NotImplemented(this));
        }
    }

    /// <summary>
    /// 出力のないUseCaseを実装します。
    /// </summary>
    /// <typeparam name="TInput">入力オブジェクト</typeparam>
    public abstract class Interactor<TInput> : Interactor<TInput, CleanResult.Void>, IUseCase<TInput>
    {
    }
}