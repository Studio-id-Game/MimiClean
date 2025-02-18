namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// UseCaseを実装します。
    /// </summary>
    /// <typeparam name="TInputData">入力構造体</typeparam>
    /// <typeparam name="TOutputData">出力構造体</typeparam>
    public abstract class Interactor<TInputData, TOutputData> : IUseCase<TInputData, TOutputData>
    {
        public abstract class InteractorError : CleanResultError
        {
            public Interactor<TInputData, TOutputData> Interactor { get; }

            protected InteractorError(Interactor<TInputData, TOutputData> interactor)
            {
                Interactor = interactor;
            }
        }

        public sealed class NotImplementedInteractorError : InteractorError
        {
            public NotImplementedInteractorError(Interactor<TInputData, TOutputData> interactor) : base(interactor)
            {
            }

            public override string Message => $"the class {Interactor.GetType().Name} is not implemented.";
        }

        public virtual CleanResult<TOutputData> Excute(in CleanResult<TInputData> input)
        {
            return CleanResult<TOutputData>.Failed(new NotImplementedInteractorError(this));
        }
    }

    /// <summary>
    /// UseCaseを実装します。
    /// </summary>
    /// <typeparam name="TInputData">入力構造体</typeparam>
    public abstract class Interactor<TInputData> : Interactor<TInputData, CleanResult.Void>, IUseCase<TInputData>
    {
    }
}