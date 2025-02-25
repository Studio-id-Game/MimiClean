namespace StudioIdGames.MimiClean.Domain.App.Adapter
{
    using IAdapter;

    public abstract class Presenter<TOutput, TResult> : IAdapterPresenter<TOutput, TResult>
    {
        public abstract CleanResult<TResult> Present(in CleanResult<TOutput> usecaseOutput);

        public CleanResult<object> Present(in CleanResult<object> usecaseOutput)
        {
            return Present(usecaseOutput.As<TOutput>()).AsObject();
        }
    }

    public abstract class Presenter<TOutput> : Presenter<TOutput, CleanResult.Void>, IAdapterPresenter<TOutput>
    {
    }

    public abstract class PresenterVoid : Presenter<CleanResult.Void>, IAdapterPresenterVoid
    {
    }
}
