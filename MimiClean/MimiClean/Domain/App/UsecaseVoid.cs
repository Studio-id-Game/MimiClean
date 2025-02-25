namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;

    /// <summary>
    /// UseCaseを実装します。
    /// </summary>
    /// <typeparam name="TInput">入力オブジェクト</typeparam>
    /// <typeparam name="TOutput">出力オブジェクト</typeparam>
    public abstract class Usecase<TInput, TOutput> : IAppUseCase<TInput, TOutput>
    {
        /// <inheritdoc/>
        public virtual CleanResult<TOutput> Excute(in CleanResult<TInput> input)
        {
            return CleanResult<TOutput>.Failed(new UseCaseError.NotImplemented(this));
        }

        public CleanResult<object> Excute(in CleanResult<object> input)
        {
            return Excute(input.As<TInput>()).AsObject();
        }
    }

    /// <summary>
    /// 出力のないUseCaseを実装します。
    /// </summary>
    /// <typeparam name="TInput">入力オブジェクト</typeparam>
    public abstract class Usecase<TInput> : Usecase<TInput, CleanResult.Void>, IAppUseCase<TInput>
    {
    }

    /// <summary>
    /// 出力のないUseCaseを実装します。
    /// </summary>
    /// <typeparam name="TInput">入力オブジェクト</typeparam>
    public abstract class UsecaseVoid : Usecase<CleanResult.Void>, IAppUseCaseVoid
    {
        public override CleanResult<CleanResult.Void> Excute(in CleanResult<CleanResult.Void> input)
        {
            return CleanResult.Success();
        }
    }
}
